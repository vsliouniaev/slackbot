// ReSharper disable InconsistentNaming

using System.Collections.Generic;

namespace slackbot.Models
{
    public class SlackResponse
    {
        public SlackResponse()
        {
        }

        public SlackResponse(string simpleMessage)
        {
            text = simpleMessage;
        }

        /// <summary>
        /// https://api.slack.com/docs/attachments
        /// </summary>
        public class Attachment
        {
            public class AttachmentField
            {
                /// <example>
                /// Priority
                /// </example>
                public string title { get; set; }

                /// <example>
                /// High
                /// </example>
                public string value { get; set; }

                public bool @short { get; set; }
            }

            /// <summary>
            /// Required plain-text summary of the attachment
            /// </summary>
            public string fallback { get; set; }

            /// <summary>
            /// #36a64f
            /// </summary>
            public string color { get; set; }

            /// <summary>
            /// Optional text that appears above the attachment block
            /// </summary>
            public string pretext { get; set; }

            /// <example>
            /// Bobby Tables
            /// </example>
            public string author_name { get; set; }

            /// <example>
            /// http://flickr.com/bobby/
            /// </example>
            public string author_link { get; set; }

            /// <example>
            /// http://flickr.com/icons/bobby.jpg
            /// </example>
            public string author_icon { get; set; }

            /// <example>
            /// Slack API Documentation
            /// </example>
            public string title { get; set; }

            /// <example>
            /// https://api.slack.com
            /// </example>
            public string title_link { get; set; }

            /// <summary>
            /// Optional text that appears in the attachment
            /// </summary>
            public string text { get; set; }

            public IEnumerable<AttachmentField> Fields { get; set; }

            public string image_url { get; set; }

            public string thumb_url { get; set; }
        }

        public string response_type { get; set; }
        public string text { get; set; }
        public IEnumerable<Attachment> attachments { get; set; } 
    }
}
