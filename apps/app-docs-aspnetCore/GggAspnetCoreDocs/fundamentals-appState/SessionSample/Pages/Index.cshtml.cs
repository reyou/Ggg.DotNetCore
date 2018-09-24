using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SessionSample.Extensions;
using SessionSample.Middleware;
using System;

namespace SessionSample.Pages
{
    #region snippet1
    public class IndexModel : PageModel
    {
        public const string SessionKeyName = "_Name";
        public const string SessionKeyAge = "_Age";
        const string SessionKeyTime = "_Time";

        public string SessionInfo_Name { get; private set; }
        public string SessionInfo_Age { get; private set; }
        public string SessionInfo_CurrentTime { get; private set; }
        public string SessionInfo_SessionTime { get; private set; }
        public string SessionInfo_MiddlewareValue { get; private set; }

        public void OnGet()
        {
            // Requires: using Microsoft.AspNetCore.Http;
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                HttpContext.Session.SetString(SessionKeyName, "The Doctor");
                HttpContext.Session.SetInt32(SessionKeyAge, 773);
            }

            string name = HttpContext.Session.GetString(SessionKeyName);
            int? age = HttpContext.Session.GetInt32(SessionKeyAge);
            #endregion
            SessionInfo_Name = name;
            SessionInfo_Age = age.ToString();

            DateTime currentTime = DateTime.Now;

            #region snippet2
            // Requires you add the Set and Get extension method mentioned in the topic.
            if (HttpContext.Session.Get<DateTime>(SessionKeyTime) == default(DateTime))
            {
                HttpContext.Session.Set<DateTime>(SessionKeyTime, currentTime);
            }
            #endregion

            SessionInfo_CurrentTime = currentTime.ToString("H:mm:ss tt");
            SessionInfo_SessionTime = HttpContext.Session.Get<DateTime>(SessionKeyTime)
                .ToString("H:mm:ss tt");

            #region snippet3
            HttpContext.Items
                .TryGetValue(HttpContextItemsMiddleware.HttpContextItemsMiddlewareKey,
                    out object middlewareSetValue);
            SessionInfo_MiddlewareValue =
                middlewareSetValue?.ToString() ?? "Middleware value not set!";
            #endregion
        }

        public IActionResult OnPostUpdateSessionDate()
        {
            HttpContext.Session.Set<DateTime>(SessionKeyTime, DateTime.Now);

            return RedirectToPage();
        }

        public IActionResult OnPostChangeAge()
        {
            Random r = new Random();

            HttpContext.Session.SetInt32(SessionKeyAge, r.Next(500, 1000));

            return RedirectToPage();
        }
    }
}
