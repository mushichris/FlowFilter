using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using FlowFilter.Data;
using FlowFilter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FlowFilter.Controllers
{
    [Authorize(Roles = "AppRule")]
    public class AppRuleController : Controller
    {
        private readonly FlowFilterContext db;
        private readonly RedisManager _redisManager;
        private readonly AppSettings _appSettings;

        public AppRuleController(FlowFilterContext context, RedisManager redisManager, IOptions<AppSettings> options)
        {
            db = context;
            _redisManager = redisManager;
            _appSettings = options.Value;
        }
        
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id) || !int.TryParse(id, out int ruleId))
            {
                return BadRequest("ruleId error.");
            }
            var rule = db.AppRules.AsNoTracking().FirstOrDefault(s => s.Id == ruleId && s.IsDeleted == false);
            if (rule == null)
            {
                return BadRequest("Can not find the rule.");
            }
            return View(rule);
        }

        public async Task<IActionResult> PcapDownload()
        {
            return View();
        }

        public async Task<IActionResult> GetPcapList(string downloadDirectory = null, int page = 1, int limit = 10)
        {
            downloadDirectory = string.IsNullOrEmpty(downloadDirectory)
                ? _appSettings.DownloadDirectory
                : downloadDirectory;
            return await GetDownloadFileList(downloadDirectory, "*.*pcap*", SearchOption.AllDirectories, page, limit);
        }

        public async Task<IActionResult> GetDownloadFileList(string downloadDirectory, string searchPattern,
            SearchOption searchOption = SearchOption.AllDirectories, int page = 1, int limit = 10)
        {
            var di = new DirectoryInfo(downloadDirectory);
            var fileInfos = di.GetFiles(searchPattern, searchOption).Select(s=>new
            {
                s.Name,s.FullName,
                Length = s.Length.ToString("N0"),
                LastWriteTime = s.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"),
                CreationTime = s.CreationTime.ToString("yyyy-MM-dd HH:mm:ss"),
            });
            var retList = new
            {
                code = 0,
                msg = "",
                count = fileInfos?.Count(),
                data = fileInfos?.Skip((page - 1) * limit).Take(limit)
            };
            return Content(JsonConvert.SerializeObject(retList));
        }

        [HttpPost]
        public async Task<IActionResult> GetFile(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }
            else
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                return File(fs, "application/octect-stream", Path.GetFileName(filePath));
            }
        }

        public async Task<IActionResult> EditOperation(AppOperation appOperation)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest("input info error");
            }
            var operationInDb = await db.AppOperations.FindAsync(appOperation.Id);
            if (operationInDb == null || operationInDb.IsDeleted)
            {
                return BadRequest("input info error");
            }
            operationInDb.Field = appOperation.Field;
            operationInDb.Type = appOperation.Type;
            operationInDb.Para = appOperation.Para;
            await db.SaveChangesAsync();
            return Ok();
        }
        public async Task<IActionResult> DeleteOperation(int? operationId)
        {
            var operationInDb = await db.AppOperations.FindAsync(operationId);
            if (operationInDb == null)
            {
                return BadRequest("input info error");
            }
            operationInDb.IsDeleted = true;
            //db.AppOperations.Remove(operationInDb);
            await db.SaveChangesAsync();
            return Ok();
        }
        public async Task<IActionResult> EditAction(AppAction appAction)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest("input info error");
            }
            var actionInDb = await db.AppActions.FindAsync(appAction.Id);
            if (actionInDb == null || actionInDb.IsDeleted)
            {
                return BadRequest("input info error");
            }
            actionInDb.Field = appAction.Field;
            actionInDb.Type = appAction.Type;
            actionInDb.Para = appAction.Para;
            await db.SaveChangesAsync();
            return Ok();
        }
        public async Task<IActionResult> DeleteAction(int? actionId)
        {
            var actionInDb = await db.AppActions.FindAsync(actionId);
            if (actionInDb == null)
            {
                return BadRequest("input info error");
            }
            actionInDb.IsDeleted = true;
            //db.AppActions.Remove(actionInDb);
            await db.SaveChangesAsync();
            return Ok();
        }
        public async Task<IActionResult> SetDump(int ruleId, bool dump)
        {
            var rule = await db.AppRules.FirstOrDefaultAsync(s => s.Id == ruleId && s.IsDeleted == false);
            if (rule == null)
            {
                return BadRequest("Can not find the rule.");
            }
            rule.Dump = dump;
            await db.SaveChangesAsync();
            return Ok();
        }
        public async Task<IActionResult> SetDrop(int ruleId, bool drop)
        {
            var rule = await db.AppRules.FirstOrDefaultAsync(s => s.Id == ruleId && s.IsDeleted == false);
            if (rule == null)
            {
                return BadRequest("Can not find the rule.");
            }
            rule.Drop = drop;
            await db.SaveChangesAsync();
            return Ok();
        }
        public async Task<IActionResult> AddOperation(AddOperationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                AppOperation operation = new AppOperation()
                {
                    AppRuleId = viewModel.AppRuleId,
                    Field = viewModel.Field,
                    Type = viewModel.Type,
                    Para = viewModel.Para
                };
                db.AppOperations.Add(operation);
                await db.SaveChangesAsync();
            }
            return Ok();
        }
        public async Task<IActionResult> AddAction(AddActionViewModel viewModel)
        {
            bool isValid = AppActionType.TryParse(Request.Form["Type"], out AppActionType type);
            if (isValid)
            {
                AppAction action = new AppAction()
                {
                    AppRuleId = viewModel.AppRuleId,
                    Type = viewModel.Type,
                    Field = viewModel.Field,
                    Para = viewModel.Para
                };
                db.AppActions.Add(action);
                await db.SaveChangesAsync();
            }
            return Ok();
        }

        public async Task<IActionResult> AddRule(string packetType)
        {
            bool ret = PacketType.TryParse(packetType, true, out PacketType inputPacketType);
            if (ret != true)
            {
                return BadRequest("packetType error.");
            }
            AppRule rule = new AppRule()
            {
                PacketType = inputPacketType,

            };
            db.AppRules.Add(rule);
            await db.SaveChangesAsync();
            return Ok(rule.Id);
        }

        public async Task<IActionResult> DeleteRule(string id)
        {
            if (string.IsNullOrEmpty(id) || !int.TryParse(id, out int ruleId))
            {
                return BadRequest("ruleId error.");
            }
            var rule = await db.AppRules.FirstOrDefaultAsync(s => s.Id == ruleId);
            if (rule == null)
            {
                return BadRequest("Can not find the rule.");
            }
            rule.IsDeleted = true;
            await db.SaveChangesAsync();
            return Ok(rule.Id);
        }

        public async Task<IActionResult> GetOperationList(int id, int page = 1, int limit = 10)
        {
            var operations = (await db.AppRules.AsNoTracking().Where(s => s.Id == id && s.IsDeleted == false)
                    .Include(s => s.Operations).FirstOrDefaultAsync())
                ?.Operations.Where(s=>s.IsDeleted == false).Select(s =>
                {
                    string type = "";
                    switch (s.Type)
                    {
                        case AppOperationType.Greater:
                            type = "&gt;";
                            break;
                        case AppOperationType.Less:
                            type = "&lt;";
                            break;
                        case AppOperationType.Equal:
                            type = "=";
                            break;
                        case AppOperationType.NotLess:
                            type = "&gt;=";
                            break;
                        case AppOperationType.NotGreater:
                            type = "&lt;=";
                            break;
                        case AppOperationType.Mask:
                            type = "MASK";
                            break;
                    }

                    return new
                    {
                        Id = s.Id,
                        Type = type,
                        Field = s.Field.ToString(),
                        Para = s.Para
                    };
                }).ToList();
            var retList = new
            {
                code = 0,
                msg = "",
                count = operations.Count(),
                data = operations.Skip((page - 1) * limit).Take(limit)
            };
            return Content(JsonConvert.SerializeObject(retList));
        }

        public async Task<IActionResult> GetActionList(int id, int page = 1, int limit = 10)
        {
            var aaa = (await db.AppRules.AsNoTracking().Where(s => s.Id == id && s.IsDeleted == false)
                    .Include(s => s.Actions).FirstOrDefaultAsync())
                ?.Actions;
            var actions = (await db.AppRules.AsNoTracking().Where(s => s.Id == id && s.IsDeleted == false)
                    .Include(s => s.Actions).FirstOrDefaultAsync())
                ?.Actions.Where(s => s.IsDeleted == false).Select(s => new
                {
                    Id = s.Id,
                    Type = AppActionTypeInfo.AllAppActionTypeInfos[s.Type].Description,
                    Field = s.Type == AppActionType.Set ? s.Field.ToString() : "",
                    Para = s.Type == AppActionType.Set ? s.Para.ToString() : ""
                }).ToList();
            var retList = new
            {
                code = 0,
                msg = "",
                count = actions?.Count(),
                data = actions?.Skip((page - 1) * limit).Take(limit)
            };
            return Content(JsonConvert.SerializeObject(retList));
        }

        public async Task<IActionResult> GetRuleList(int page = 1, int limit = 10)
        {
            var rules = await db.AppRules.AsNoTracking().Where(s=>s.IsDeleted == false).Select(s => new
            {
                Id = s.Id,
                PacketType = s.PacketType.ToString(),
                OperationCount = s.Operations.Count(t => t.IsDeleted == false),
                ActionCount = s.Actions.Count(t => t.IsDeleted == false)
            }).ToListAsync();
            var retList = new
            {
                code = 0,
                msg = "",
                count = rules?.Count(),
                data = rules?.Skip((page - 1) * limit).Take(limit)
            };
            return Content(JsonConvert.SerializeObject(retList));
        }

        public async Task<IActionResult> ApplyRules(List<AppRule> appRules, bool applyAll = false)
        {
            AppConfig appConfig = new AppConfig()
            {
                Rules = new List<AppRule>()
            };
            if (applyAll)
            {
                var appRulesInDb = await db.AppRules.AsNoTracking().Include(s => s.Actions).Include(s => s.Operations)
                    .Where(s => s.IsDeleted == false).ToListAsync();
                appRulesInDb.ForEach(appRuleInDb =>
                {
                    appRuleInDb.Operations = appRuleInDb.Operations.Where(s => s.IsDeleted == false).OrderBy(s => FieldInfo.AllFieldInfos[s.Field].Level)
                        .ToList();
                    appRuleInDb.Actions = appRuleInDb.Drop
                        ? new List<AppAction>()
                        : appRuleInDb.Actions.Where(s => s.IsDeleted == false).OrderBy(s => FieldInfo.AllFieldInfos[s.Field].Level).ToList();
                });
                appConfig.Rules.AddRange(appRulesInDb);
            }
            else
            {
                foreach (AppRule appRule in appRules)
                {
                    var appRuleInDb = await db.AppRules.AsNoTracking().Include(s => s.Actions).Include(s => s.Operations)
                        .FirstOrDefaultAsync(s => s.Id == appRule.Id && s.IsDeleted == false);
                    if (appRuleInDb == null)
                    {
                        continue;
                    }
                    appRuleInDb.Operations = appRuleInDb.Operations.Where(s => s.IsDeleted == false).OrderBy(s => FieldInfo.AllFieldInfos[s.Field].Level).ToList();
                    appRuleInDb.Actions = appRuleInDb.Drop
                        ? new List<AppAction>()
                        : appRuleInDb.Actions.Where(s => s.IsDeleted == false).OrderBy(s => FieldInfo.AllFieldInfos[s.Field].Level).ToList();
                    appConfig.Rules.Add(appRuleInDb);
                }
            }
            string applyStr = ToolClass.XmlSerialize(appConfig);
            _redisManager.Instance.GetDatabase().StringSet("CONFIG", applyStr);
            _redisManager.Instance.GetDatabase().StringSet("CMD", (int)BackendCommand.Updating);
            return Ok();
        }



        //public async Task<IActionResult> Test()
        //{
        //    AppConfig appConfig = new AppConfig()
        //    {
        //        Rules = new List<AppRule>()
        //        {
        //            new AppRule()
        //            {
        //                PacketType = PacketType.OSPFv2_HEADER,
        //                Operations = new List<AppOperation>()
        //                {
        //                    new AppOperation()
        //                    {
        //                        Field = PROTOCOL_FIELD.OSPFv2_HEADER_VERSION,
        //                        Para = 1,
        //                        Type = AppOperationType.Greater
        //                    },
        //                    new AppOperation()
        //                    {
        //                        Field = PROTOCOL_FIELD.OSPFv2_HEADER_PACKET_LENGTH,
        //                        Para = 100,
        //                        Type = AppOperationType.Less
        //                    },
        //                },
        //                Actions = new List<AppAction>()
        //                {
        //                    new AppAction()
        //                    {
        //                        Type = AppActionType.Drop
        //                    },
        //                    new AppAction()
        //                    {
        //                        Field = PROTOCOL_FIELD.OSPFv2_HEADER_TYPE,
        //                        Type = AppActionType.Set,
        //                        Para = 3
        //                    }
        //                }
        //            }
        //        }
        //    };
        //    db.AppRules.AddRange(appConfig.Rules);
        //    await db.SaveChangesAsync();
        //    string abc = ToolClass.XmlSerialize(appConfig);
        //    return Content(abc);
        //}
    }
}