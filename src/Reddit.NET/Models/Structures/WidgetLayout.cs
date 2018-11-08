﻿using Newtonsoft.Json;
using System;

namespace Reddit.NET.Models.Structures
{
    [Serializable]
    public class WidgetLayout
    {
        [JsonProperty("idCardWidget")]
        public string IdCardWidget;

        [JsonProperty("topbar")]
        public WidgetLayoutOrder Topbar;

        [JsonProperty("sidebar")]
        public WidgetLayoutOrder Sidebar;

        [JsonProperty("moderatorWidget")]
        public string ModeratorWidget;
    }
}
