using BowlingApp.Models;
using BowlingApp.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BowlingApp.Controllers.Api
{
    public class HomeApiController : ApiController
    {
        private BowlingService _bowlingService = null;

        public HomeApiController()
        {
            _bowlingService = new BowlingService();
        }

        [HttpPost]
        public IHttpActionResult CalculateScore([FromBody]FramesModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Json object was empty");
            }

            var score = _bowlingService.CalculateScore(model.Frames);

            return Ok(score);
        }
    }
}

