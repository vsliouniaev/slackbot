using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using slackbot.Commands;
using slackbot.Models;

namespace slackbot.Controllers
{
    [Route("")]
    public class SlackController : Controller
    {
        private readonly JiraCommand _jiraCommand;    

        public SlackController(IOptions<AppSettings> settings)
        {
            _jiraCommand = new JiraCommand(settings.Value.JiraCommandUrl);
        }

        [HttpPost]
        public SlackResponse Post(SlackRequest request)
        {
            return _jiraCommand.ProcessRequest(request);
        }
    }
}
