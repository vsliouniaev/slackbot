using System;
using System.Linq;
using System.Text.RegularExpressions;
using slackbot.Models;

namespace slackbot.Commands
{
    public class JiraCommand
    {
        ///<remarks>
        /// https://confluence.atlassian.com/display/STASHKB/Integrating+with+custom+JIRA+issue+key
        /// </remarks>
        private static readonly Regex JiraTicketRegex = new Regex("(?i)((?<!([A-Z]{1,10})-?)[A-Z]+-\\d+)", RegexOptions.Compiled);

        private readonly string _jiraUrl;

        public JiraCommand(string jiraUrl)
        {
            _jiraUrl = jiraUrl;
        }

        public SlackResponse ProcessRequest(SlackRequest request)
        {
            try
            {
                if (request.text == null)
                {
                    return new SlackResponse("Please type some text containing a jira ticket key");
                }
                var jiraKeys = JiraTicketRegex.Matches(request.text).Cast<Match>();
                if (!jiraKeys.Any())
                {
                    return   new SlackResponse("Couldn't find any ticket keys");
                }

                var attachments = jiraKeys.Select(match => new SlackResponse.Attachment
                {
                    fallback = _jiraUrl + match,
                    text = string.Format("<{0}{1}|{1}>", _jiraUrl, match.ToString().ToUpper()),
                    color = "good"
                });

                return new SlackResponse
                {
                    response_type = "in_channel",
                    attachments = attachments
                };
            }
            catch (Exception ex)
            {
                return
                    new SlackResponse($"Unable to parse request text '{request.text}', got an error '{ex.StackTrace}'");
            }
        }
    }
}
