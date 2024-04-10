namespace NSGE.CrossCutting.Ajax
{
    public class AjaxOptions
    {
        public AjaxOptions()
        { }

        //
        // Summary:
        //     Gets or sets the message to display in a confirmation window before a request
        //     is submitted.
        //
        // Returns:
        //     The message to display in a confirmation window.
        public string Confirm { get; set; }

        //
        // Summary:
        //     Gets or sets the HTTP request method ("Get" or "Post").
        //
        // Returns:
        //     The HTTP request method. The default value is "Post".
        public string HttpMethod { get; set; }

        //
        // Summary:
        //     Gets or sets the mode that specifies how to insert the response into the target
        //     DOM element.
        //
        // Returns:
        //     The insertion mode ("InsertAfter", "InsertBefore", or "Replace"). The default
        //     value is "Replace".
        //public InsertionMode InsertionMode { get; set; }

        //
        // Summary:
        //     Gets or sets a value, in milliseconds, that controls the duration of the animation
        //     when showing or hiding the loading element.
        //
        // Returns:
        //     A value, in milliseconds, that controls the duration of the animation when showing
        //     or hiding the loading element.
        public int LoadingElementDuration { get; set; }

        //
        // Summary:
        //     Gets or sets the id attribute of an HTML element that is displayed while the
        //     Ajax function is loading.
        //
        // Returns:
        //     The ID of the element that is displayed while the Ajax function is loading.
        public string LoadingElementId { get; set; }

        //
        // Summary:
        //     Gets or sets the name of the JavaScript function to call immediately before the
        //     page is updated.
        //
        // Returns:
        //     The name of the JavaScript function to call before the page is updated.
        public string OnBegin { get; set; }

        //
        // Summary:
        //     Gets or sets the JavaScript function to call when response data has been instantiated
        //     but before the page is updated.
        //
        // Returns:
        //     The JavaScript function to call when the response data has been instantiated.
        public string OnComplete { get; set; }

        //
        // Summary:
        //     Gets or sets the JavaScript function to call if the page update fails.
        //
        // Returns:
        //     The JavaScript function to call if the page update fails.
        public string OnFailure { get; set; }

        //
        // Summary:
        //     Gets or sets the JavaScript function to call after the page is successfully updated.
        //
        // Returns:
        //     The JavaScript function to call after the page is successfully updated.
        public string OnSuccess { get; set; }

        //
        // Summary:
        //     Gets or sets the ID of the DOM element to update by using the response from the
        //     server.
        //
        // Returns:
        //     The ID of the DOM element to update.
        public string UpdateTargetId { get; set; }

        //
        // Summary:
        //     Gets or sets the URL to make the request to.
        //
        // Returns:
        //     The URL to make the request to.
        public string Url { get; set; }

        public bool AllowCache { get; set; }

        //
        // Summary:
        //     Returns the Ajax options as a collection of HTML attributes to support unobtrusive
        //     JavaScript.
        //
        // Returns:
        //     The Ajax options as a collection of HTML attributes to support unobtrusive JavaScript.
        public IDictionary<string, object> ToUnobtrusiveHtmlAttributes { get; set; }
    }
}