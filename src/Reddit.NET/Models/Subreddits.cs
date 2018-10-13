﻿using Newtonsoft.Json;
using Reddit.NET.Models.Structures;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reddit.NET.Models
{
    public class Subreddits : BaseModel
    {
        internal override RestClient RestClient { get; set; }

        public Subreddits(string appId, string refreshToken, string accessToken, RestClient restClient) : base(appId, refreshToken, accessToken, restClient) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="after">fullname of a thing</param>
        /// <param name="before">fullname of a thing</param>
        /// <param name="user"></param>
        /// <param name="includeCategories"></param>
        /// <param name="subreddit"></param>
        /// <param name="count"></param>
        /// <param name="limit"></param>
        /// <param name="show"></param>
        /// <param name="srDetail"></param>
        /// <returns></returns>
        public object About(string where, string after, string before, string user, bool includeCategories, string subreddit = null, int count = 0,
            int limit = 25, string show = "all", bool srDetail = false)
        {
            RestRequest restRequest = PrepareRequest(Sr(subreddit) + "about/" + where);

            restRequest.AddParameter("after", after);
            restRequest.AddParameter("before", before);
            restRequest.AddParameter("user", user);
            restRequest.AddParameter("include_categories", includeCategories);
            restRequest.AddParameter("count", count);
            restRequest.AddParameter("limit", limit);
            restRequest.AddParameter("show", show);
            restRequest.AddParameter("sr_detail", srDetail);

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        // TODO - Needs testing.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subreddit"></param>
        /// <returns>(TODO - Untested)</returns>
        public object DeleteSrBanner(string subreddit = null)
        {
            RestRequest restRequest = PrepareRequest(Sr(subreddit) + "api/delete_sr_banner", Method.POST);

            restRequest.AddParameter("api_type", "json");

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        // TODO - Needs testing.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subreddit"></param>
        /// <returns>(TODO - Untested)</returns>
        public object DeleteSrHeader(string subreddit = null)
        {
            RestRequest restRequest = PrepareRequest(Sr(subreddit) + "api/delete_sr_header", Method.POST);

            restRequest.AddParameter("api_type", "json");

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        // TODO - Needs testing.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subreddit"></param>
        /// <returns>(TODO - Untested)</returns>
        public object DeleteSrIcon(string subreddit = null)
        {
            RestRequest restRequest = PrepareRequest(Sr(subreddit) + "api/delete_sr_icon", Method.POST);

            restRequest.AddParameter("api_type", "json");

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        // TODO - Needs testing.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imgName"></param>
        /// <param name="subreddit"></param>
        /// <returns>(TODO - Untested)</returns>
        public object DeleteSrImg(string imgName, string subreddit = null)
        {
            RestRequest restRequest = PrepareRequest(Sr(subreddit) + "api/delete_sr_img", Method.POST);

            restRequest.AddParameter("img_name", imgName);
            restRequest.AddParameter("api_type", "json");

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="srNames"></param>
        /// <param name="omit"></param>
        /// <param name="over18"></param>
        /// <returns></returns>
        public object Recommend(string srNames, string omit, bool over18)
        {
            RestRequest restRequest = PrepareRequest("api/recommend/sr/" + srNames);

            restRequest.AddParameter("omit", omit);
            restRequest.AddParameter("over_18", over18);

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exact"></param>
        /// <param name="includeOver18"></param>
        /// <param name="includeUnadvertisable"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public object SearchRedditNames(bool exact, bool includeOver18, bool includeUnadvertisable, string query)
        {
            RestRequest restRequest = PrepareRequest("api/search_reddit_names");

            restRequest.AddParameter("exact", exact);
            restRequest.AddParameter("include_over_18", includeOver18);
            restRequest.AddParameter("include_unadvertisable", includeUnadvertisable);
            restRequest.AddParameter("query", query);

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exact"></param>
        /// <param name="includeOver18"></param>
        /// <param name="includeUnadvertisable"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public object SearchSubreddits(bool exact, bool includeOver18, bool includeUnadvertisable, string query)
        {
            RestRequest restRequest = PrepareRequest("api/search_subreddits", Method.POST);

            restRequest.AddParameter("exact", exact);
            restRequest.AddParameter("include_over_18", includeOver18);
            restRequest.AddParameter("include_unadvertisable", includeUnadvertisable);
            restRequest.AddParameter("query", query);

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="allOriginalContent"></param>
        /// <param name="allowDiscovery"></param>
        /// <param name="allowImages"></param>
        /// <param name="allowPostCrossposts"></param>
        /// <param name="allowTop"></param>
        /// <param name="allowVideos"></param>
        /// <param name="collapseDeletedComments"></param>
        /// <param name="description"></param>
        /// <param name="excludeBannedModqueue"></param>
        /// <param name="freeFormReports"></param>
        /// <param name="gRecaptchaResponse"></param>
        /// <param name="headerTitle"></param>
        /// <param name="hideAds"></param>
        /// <param name="keyColor"></param>
        /// <param name="lang"></param>
        /// <param name="linkType"></param>
        /// <param name="name"></param>
        /// <param name="originalContentTagEnabled"></param>
        /// <param name="over18"></param>
        /// <param name="publicDescription"></param>
        /// <param name="showMedia"></param>
        /// <param name="showMediaPreview"></param>
        /// <param name="spamComments"></param>
        /// <param name="spamLinks"></param>
        /// <param name="spamSelfPosts"></param>
        /// <param name="spoilersEnabled"></param>
        /// <param name="sr">fullname of a thing</param>
        /// <param name="submitLinkLabel"></param>
        /// <param name="submitText"></param>
        /// <param name="submitTextLabel"></param>
        /// <param name="suggestedCommentSort"></param>
        /// <param name="themeSr"></param>
        /// <param name="themeSrUpdate"></param>
        /// <param name="title"></param>
        /// <param name="type"></param>
        /// <param name="wikiMode"></param>
        /// <param name="commentScoreHideMins"></param>
        /// <param name="wikiEditAge"></param>
        /// <param name="wikiEditKarma"></param>
        /// <returns></returns>
        public object SiteAdmin(bool allOriginalContent, bool allowDiscovery, bool allowImages, bool allowPostCrossposts, bool allowTop,
            bool allowVideos, bool collapseDeletedComments, string description, bool excludeBannedModqueue, bool freeFormReports,
            string gRecaptchaResponse, string headerTitle, bool hideAds, string keyColor, string lang, string linkType, string name, bool originalContentTagEnabled,
            bool over18, string publicDescription, bool showMedia, bool showMediaPreview, string spamComments, string spamLinks, string spamSelfPosts,
            bool spoilersEnabled, string sr, string submitLinkLabel, string submitText, string submitTextLabel, string suggestedCommentSort,
            string themeSr, bool themeSrUpdate, string title, string type, string wikiMode, int commentScoreHideMins = 0, int wikiEditAge = 0,
            int wikiEditKarma = 0)
        {
            RestRequest restRequest = PrepareRequest("api/site_admin", Method.POST);

            restRequest.AddParameter("all_original_content", allOriginalContent);
            restRequest.AddParameter("allow_discovery", allowDiscovery);
            restRequest.AddParameter("allow_images", allowImages);
            restRequest.AddParameter("allow_post_crossposts", allowPostCrossposts);
            restRequest.AddParameter("allow_top", allowTop);
            restRequest.AddParameter("allow_videos", allowVideos);
            restRequest.AddParameter("collapse_deleted_comments", collapseDeletedComments);
            restRequest.AddParameter("comment_score_hide_mins", commentScoreHideMins);
            restRequest.AddParameter("description", description);
            restRequest.AddParameter("exclude_banned_modqueue", excludeBannedModqueue);
            restRequest.AddParameter("free_form_reports", freeFormReports);
            restRequest.AddParameter("g-recaptcha-response", gRecaptchaResponse);
            restRequest.AddParameter("header-title", headerTitle);
            restRequest.AddParameter("hide_ads", hideAds);
            restRequest.AddParameter("key_color", keyColor);
            restRequest.AddParameter("lang", lang);
            restRequest.AddParameter("link_type", linkType);
            restRequest.AddParameter("name", name);
            restRequest.AddParameter("original_content_tag_enabled", originalContentTagEnabled);
            restRequest.AddParameter("over_18", over18);
            restRequest.AddParameter("public_description", publicDescription);
            restRequest.AddParameter("show_media", showMedia);
            restRequest.AddParameter("show_media_preview", showMediaPreview);
            restRequest.AddParameter("spam_comments", spamComments);
            restRequest.AddParameter("spam_links", spamLinks);
            restRequest.AddParameter("spam_selfposts", spamSelfPosts);
            restRequest.AddParameter("spoilers_enabled", spoilersEnabled);
            restRequest.AddParameter("sr", sr);
            restRequest.AddParameter("submit_link_label", submitLinkLabel);
            restRequest.AddParameter("submit_text", submitText);
            restRequest.AddParameter("submit_text_label", submitTextLabel);
            restRequest.AddParameter("suggested_comment_sort", suggestedCommentSort);
            restRequest.AddParameter("theme_sr", themeSr);
            restRequest.AddParameter("theme_sr_update", themeSrUpdate);
            restRequest.AddParameter("title", title);
            restRequest.AddParameter("type", type);
            restRequest.AddParameter("wiki_edit_age", wikiEditAge);
            restRequest.AddParameter("wiki_edit_karma", wikiEditKarma);
            restRequest.AddParameter("wikimode", wikiMode);
            restRequest.AddParameter("api_type", "json");

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subreddit"></param>
        /// <returns></returns>
        public object SubmitText(string subreddit = null)
        {
            return JsonConvert.DeserializeObject(ExecuteRequest(Sr(subreddit) + "api/submit_text"));
        }

        // TODO - Needs testing.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="includeOver18"></param>
        /// <param name="includeProfiles"></param>
        /// <param name="query"></param>
        /// <returns>(TODO - Untested)</returns>
        public object SubredditAutocomplete(bool includeOver18, bool includeProfiles, string query)
        {
            RestRequest restRequest = PrepareRequest("api/subreddit_autocomplete");

            restRequest.AddParameter("include_over_18", includeOver18);
            restRequest.AddParameter("include_profiles", includeProfiles);
            restRequest.AddParameter("query", query);

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        // TODO - Needs testing.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="includeCategories"></param>
        /// <param name="includeOver18"></param>
        /// <param name="includeProfiles"></param>
        /// <param name="query"></param>
        /// <param name="limit"></param>
        /// <returns>(TODO - Untested)</returns>
        public object SubredditAutocompleteV2(bool includeCategories, bool includeOver18, bool includeProfiles, string query, int limit = 5)
        {
            RestRequest restRequest = PrepareRequest("api/subreddit_autocomplete_v2");

            restRequest.AddParameter("include_categories", includeCategories);
            restRequest.AddParameter("include_over_18", includeOver18);
            restRequest.AddParameter("include_profiles", includeProfiles);
            restRequest.AddParameter("query", query);
            restRequest.AddParameter("limit", limit);

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        // TODO - Needs testing.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="op"></param>
        /// <param name="reason"></param>
        /// <param name="stylesheetContents"></param>
        /// <param name="subreddit"></param>
        /// <returns>(TODO - Untested)</returns>
        public object SubredditStylesheet(string op, string reason, string stylesheetContents, string subreddit = null)
        {
            RestRequest restRequest = PrepareRequest(Sr(subreddit) + "api/subreddit_stylesheet", Method.POST);

            restRequest.AddParameter("op", op);
            restRequest.AddParameter("reason", reason);
            restRequest.AddParameter("stylesheet_contents", stylesheetContents);
            restRequest.AddParameter("api_type", "json");

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        // TODO - Needs testing.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="skipInitialDefaults"></param>
        /// <param name="sr"></param>
        /// <returns>(TODO - Untested)</returns>
        public object SubscribeByFullname(string action, bool skipInitialDefaults, string sr)
        {
            RestRequest restRequest = PrepareRequest("api/subscribe", Method.POST);

            restRequest.AddParameter("action", action);
            restRequest.AddParameter("skip_initial_defaults", skipInitialDefaults);
            restRequest.AddParameter("sr", sr);

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        // TODO - Needs testing.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="skipInitialDefaults"></param>
        /// <param name="srName"></param>
        /// <returns>(TODO - Untested)</returns>
        public object Subscribe(string action, bool skipInitialDefaults, string srName)
        {
            RestRequest restRequest = PrepareRequest("api/subscribe", Method.POST);

            restRequest.AddParameter("action", action);
            restRequest.AddParameter("skip_initial_defaults", skipInitialDefaults);
            restRequest.AddParameter("sr_name", srName);

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        // TODO - Needs testing.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="header"></param>
        /// <param name="name"></param>
        /// <param name="uploadType"></param>
        /// <param name="subreddit"></param>
        /// <param name="imgType"></param>
        /// <param name="formId"></param>
        /// <returns>(TODO - Untested)</returns>
        public object UploadSrImg(byte[] file, int header, string name, string uploadType, string subreddit = null, string imgType = "png",
            string formId = null)
        {
            RestRequest restRequest = PrepareRequest(Sr(subreddit) + "api/upload_sr_img", Method.POST);

            restRequest.AddParameter("file", file);
            restRequest.AddParameter("header", header);
            restRequest.AddParameter("name", name);
            restRequest.AddParameter("upload_type", uploadType);
            restRequest.AddParameter("img_type", imgType);
            restRequest.AddParameter("formid", formId);

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        // TODO - Needs testing.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="after">fullname of a thing</param>
        /// <param name="before">fullname of a thing</param>
        /// <param name="q"></param>
        /// <param name="sort"></param>
        /// <param name="count"></param>
        /// <param name="limit"></param>
        /// <param name="show"></param>
        /// <param name="srDetail"></param>
        /// <returns>(TODO - Untested)</returns>
        public object SearchProfiles(string after, string before, string q, string sort, int count = 0, int limit = 25, string show = "all",
            bool srDetail = false)
        {
            RestRequest restRequest = PrepareRequest("profiles/search");

            restRequest.AddParameter("after", after);
            restRequest.AddParameter("before", before);
            restRequest.AddParameter("count", count);
            restRequest.AddParameter("limit", limit);
            restRequest.AddParameter("q", q);
            restRequest.AddParameter("show", show);
            restRequest.AddParameter("sort", sort);
            restRequest.AddParameter("sr_detail", srDetail);

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subreddit"></param>
        /// <returns></returns>
        public object About(string subreddit)
        {
            return JsonConvert.DeserializeObject(ExecuteRequest("r/" + subreddit + "/about"));
        }

        // TODO - Needs testing.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subreddit"></param>
        /// <param name="created"></param>
        /// <param name="location"></param>
        /// <returns>(TODO - Untested)</returns>
        public object Edit(string subreddit, bool created, string location)
        {
            RestRequest restRequest = PrepareRequest("r/" + subreddit + "/about/edit");

            restRequest.AddParameter("created", created);
            restRequest.AddParameter("location", location);

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subreddit"></param>
        /// <returns></returns>
        public object Rules(string subreddit)
        {
            return JsonConvert.DeserializeObject(ExecuteRequest("r/" + subreddit + "/about/rules"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subreddit"></param>
        /// <returns></returns>
        public object Traffic(string subreddit)
        {
            return JsonConvert.DeserializeObject(ExecuteRequest("r/" + subreddit + "/about/traffic"));
        }

        /*
         * Note - The API docs show the wrong URL for this endpoint.
         * According to multiple sources, this endpoint is incompatible with OAuth.  It just returns empty JSON.
         * 
         * --Kris
         */
        public object Sidebar(string subreddit = null)
        {
            throw new NotImplementedException("This endpoint does not work correctly with OAuth.");
            //return JsonConvert.DeserializeObject(ExecuteRequest(Sr(subreddit) + "about/sidebar"));
        }

        /* Note - The API docs show the wrong URL for this endpoint (I think).
         * This endpoint returns 403, with the content saying, "Request forbidden by administrative rules."
         * The response object does contain the URL of the stickied post, though, interestingly enough.
         * 
         * --Kris
         */
        public object Sticky(string subreddit = null, int num = 1)
        {
            RestRequest restRequest = PrepareRequest(Sr(subreddit) + "about/sticky");

            restRequest.AddParameter("num", num);

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="after">fullname of a thing</param>
        /// <param name="before">fullname of a thing</param>
        /// <param name="includeCategories"></param>
        /// <param name="count"></param>
        /// <param name="limit"></param>
        /// <param name="show"></param>
        /// <param name="srDetail"></param>
        /// <returns></returns>
        public object Mine(string where, string after, string before, bool includeCategories, int count = 0, int limit = 25,
            string show = "all", bool srDetail = false)
        {
            RestRequest restRequest = PrepareRequest("subreddits/mine/" + where);

            restRequest.AddParameter("after", after);
            restRequest.AddParameter("before", before);
            restRequest.AddParameter("include_categories", includeCategories);
            restRequest.AddParameter("count", count);
            restRequest.AddParameter("limit", limit);
            restRequest.AddParameter("show", show);
            restRequest.AddParameter("sr_detail", srDetail);

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="after">fullname of a thing</param>
        /// <param name="before">fullname of a thing</param>
        /// <param name="q"></param>
        /// <param name="showUsers"></param>
        /// <param name="sort"></param>
        /// <param name="count"></param>
        /// <param name="limit"></param>
        /// <param name="show"></param>
        /// <param name="srDetail"></param>
        /// <returns></returns>
        public object Search(string after, string before, string q, bool showUsers, string sort, int count = 0, int limit = 25,
            string show = "all", bool srDetail = false)
        {
            RestRequest restRequest = PrepareRequest("subreddits/search");

            restRequest.AddParameter("after", after);
            restRequest.AddParameter("before", before);
            restRequest.AddParameter("q", q);
            restRequest.AddParameter("show_users", showUsers);
            restRequest.AddParameter("sort", sort);
            restRequest.AddParameter("count", count);
            restRequest.AddParameter("limit", limit);
            restRequest.AddParameter("show", show);
            restRequest.AddParameter("sr_detail", srDetail);

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="after">fullname of a thing</param>
        /// <param name="before">fullname of a thing</param>
        /// <param name="includeCategories"></param>
        /// <param name="count"></param>
        /// <param name="limit"></param>
        /// <param name="show"></param>
        /// <param name="srDetail"></param>
        /// <returns></returns>
        public object Get(string where, string after, string before, bool includeCategories, int count = 0, int limit = 25,
            string show = "all", bool srDetail = false)
        {
            RestRequest restRequest = PrepareRequest("subreddits/" + where);

            restRequest.AddParameter("after", after);
            restRequest.AddParameter("before", before);
            restRequest.AddParameter("include_categories", includeCategories);
            restRequest.AddParameter("count", count);
            restRequest.AddParameter("limit", limit);
            restRequest.AddParameter("show", show);
            restRequest.AddParameter("sr_detail", srDetail);

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="after">fullname of a thing</param>
        /// <param name="before">fullname of a thing</param>
        /// <param name="includeCategories"></param>
        /// <param name="count"></param>
        /// <param name="limit"></param>
        /// <param name="show"></param>
        /// <param name="srDetail"></param>
        /// <returns></returns>
        public object GetUserSubreddits(string where, string after, string before, bool includeCategories, int count = 0, int limit = 25,
            string show = "all", bool srDetail = false)
        {
            RestRequest restRequest = PrepareRequest("users/" + where);

            restRequest.AddParameter("after", after);
            restRequest.AddParameter("before", before);
            restRequest.AddParameter("include_categories", includeCategories);
            restRequest.AddParameter("count", count);
            restRequest.AddParameter("limit", limit);
            restRequest.AddParameter("show", show);
            restRequest.AddParameter("sr_detail", srDetail);

            return JsonConvert.DeserializeObject(ExecuteRequest(restRequest));
        }
    }
}
