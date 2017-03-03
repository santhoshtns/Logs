﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Models.Entries;
using Logs.Web.Models.Logs;
using PagedList;

namespace Logs.Web.Controllers
{
    public class EntriesController : Controller
    {
        private readonly IEntryService entryService;
        private readonly IAuthenticationProvider authenticationProvider;

        public EntriesController(IEntryService entryService, IAuthenticationProvider authenticationProvider)
        {
            this.entryService = entryService;
            this.authenticationProvider = authenticationProvider;
        }

        public ActionResult NewEntry(NewEntryViewModel model)
        {
            this.entryService.AddEntryToLog(model.Content, model.LogId);

            return null;
        }

        public ActionResult Comment(NewCommentViewModel model)
        {
            model.UserId = authenticationProvider.CurrentUserId;

            this.entryService.AddCommentToLog(model.Content, model.LogId, model.UserId);

            return null;
        }
    }
}