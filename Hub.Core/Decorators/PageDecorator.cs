using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ConsoleLogging = System.Console;
namespace Hub.Core.Decorators
{
    public class PageDecorator : IPageDecorator
    {
        private readonly IPage Page;

        public PageDecorator(IPage page)
        {
            Page = page;

        }

        public IAccessibility Accessibility => Page.Accessibility;

        public IBrowserContext Context => Page.Context;

        public IReadOnlyList<IFrame> Frames => Page.Frames;

        public bool IsClosed => Page.IsClosed;

        public IKeyboard Keyboard => throw new NotImplementedException();

        public IFrame MainFrame => Page.MainFrame;

        public IMouse Mouse => throw new NotImplementedException();

        public ITouchscreen Touchscreen => throw new NotImplementedException();

        public string Url => throw new NotImplementedException();

        public IVideo Video => throw new NotImplementedException();

        public PageViewportSizeResult ViewportSize => throw new NotImplementedException();

        public IReadOnlyList<IWorker> Workers => throw new NotImplementedException();

        public IAPIRequestContext APIRequest => throw new NotImplementedException();

        public event EventHandler<IPage> Close;
        public event EventHandler<IConsoleMessage> Console;
        public event EventHandler<IPage> Crash;
        public event EventHandler<IDialog> Dialog;
        public event EventHandler<IPage> DOMContentLoaded;
        public event EventHandler<IDownload> Download;
        public event EventHandler<IFileChooser> FileChooser;
        public event EventHandler<IFrame> FrameAttached;
        public event EventHandler<IFrame> FrameDetached;
        public event EventHandler<IFrame> FrameNavigated;
        public event EventHandler<IPage> Load;
        public event EventHandler<string> PageError;
        public event EventHandler<IPage> Popup;
        public event EventHandler<IRequest> Request;
        public event EventHandler<IRequest> RequestFailed;
        public event EventHandler<IRequest> RequestFinished;
        public event EventHandler<IResponse> Response;
        public event EventHandler<IWebSocket> WebSocket;
        public event EventHandler<IWorker> Worker;

        public Task AddInitScriptAsync(string script = null, string scriptPath = null)
        {
            throw new NotImplementedException();
        }

        public Task<IElementHandle> AddScriptTagAsync(PageAddScriptTagOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IElementHandle> AddStyleTagAsync(PageAddStyleTagOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task BringToFrontAsync()
        {
            throw new NotImplementedException();
        }

        public Task CheckAsync(string selector, PageCheckOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task ClickAsync(string selector, PageClickOptions options = null)
        {
            ConsoleLogging.WriteLine("Element Clicked");
            return Page.ClickAsync(selector, options);
        }

        public Task CloseAsync(PageCloseOptions options = null)
        {
            return Page.CloseAsync(options);
        }

        public Task<string> ContentAsync()
        {
            throw new NotImplementedException();
        }

        public Task DblClickAsync(string selector, PageDblClickOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task DispatchEventAsync(string selector, string type, object eventInit = null, PageDispatchEventOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task DragAndDropAsync(string source, string target, PageDragAndDropOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task EmulateMediaAsync(PageEmulateMediaOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> EvalOnSelectorAllAsync<T>(string selector, string expression, object arg = null)
        {
            throw new NotImplementedException();
        }

        public Task<JsonElement?> EvalOnSelectorAllAsync(string selector, string expression, object arg = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> EvalOnSelectorAsync<T>(string selector, string expression, object arg = null, PageEvalOnSelectorOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<JsonElement?> EvalOnSelectorAsync(string selector, string expression, object arg = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> EvaluateAsync<T>(string expression, object arg = null)
        {
            throw new NotImplementedException();
        }

        public Task<JsonElement?> EvaluateAsync(string expression, object arg = null)
        {
            throw new NotImplementedException();
        }

        public Task<IJSHandle> EvaluateHandleAsync(string expression, object arg = null)
        {
            throw new NotImplementedException();
        }

        public Task ExposeBindingAsync(string name, Action callback, PageExposeBindingOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task ExposeBindingAsync(string name, Action<BindingSource> callback)
        {
            throw new NotImplementedException();
        }

        public Task ExposeBindingAsync<T>(string name, Action<BindingSource, T> callback)
        {
            throw new NotImplementedException();
        }

        public Task ExposeBindingAsync<TResult>(string name, Func<BindingSource, TResult> callback)
        {
            throw new NotImplementedException();
        }

        public Task ExposeBindingAsync<TResult>(string name, Func<BindingSource, IJSHandle, TResult> callback)
        {
            throw new NotImplementedException();
        }

        public Task ExposeBindingAsync<T, TResult>(string name, Func<BindingSource, T, TResult> callback)
        {
            throw new NotImplementedException();
        }

        public Task ExposeBindingAsync<T1, T2, TResult>(string name, Func<BindingSource, T1, T2, TResult> callback)
        {
            throw new NotImplementedException();
        }

        public Task ExposeBindingAsync<T1, T2, T3, TResult>(string name, Func<BindingSource, T1, T2, T3, TResult> callback)
        {
            throw new NotImplementedException();
        }

        public Task ExposeBindingAsync<T1, T2, T3, T4, TResult>(string name, Func<BindingSource, T1, T2, T3, T4, TResult> callback)
        {
            throw new NotImplementedException();
        }

        public Task ExposeFunctionAsync(string name, Action callback)
        {
            throw new NotImplementedException();
        }

        public Task ExposeFunctionAsync<T>(string name, Action<T> callback)
        {
            throw new NotImplementedException();
        }

        public Task ExposeFunctionAsync<TResult>(string name, Func<TResult> callback)
        {
            throw new NotImplementedException();
        }

        public Task ExposeFunctionAsync<T, TResult>(string name, Func<T, TResult> callback)
        {
            throw new NotImplementedException();
        }

        public Task ExposeFunctionAsync<T1, T2, TResult>(string name, Func<T1, T2, TResult> callback)
        {
            throw new NotImplementedException();
        }

        public Task ExposeFunctionAsync<T1, T2, T3, TResult>(string name, Func<T1, T2, T3, TResult> callback)
        {
            throw new NotImplementedException();
        }

        public Task ExposeFunctionAsync<T1, T2, T3, T4, TResult>(string name, Func<T1, T2, T3, T4, TResult> callback)
        {
            throw new NotImplementedException();
        }

        public Task FillAsync(string selector, string value, PageFillOptions options = null)
        {
            ConsoleLogging.WriteLine($"Element Text = {value}");
            return Page.FillAsync(selector, value, options);
        }

        public Task FocusAsync(string selector, PageFocusOptions options = null)
        {
            throw new NotImplementedException();
        }

        public IFrame Frame(string name)
        {
            return Page.Frame(name);
        }

        public IFrame FrameByUrl(string url)
        {
            throw new NotImplementedException();
        }

        public IFrame FrameByUrl(Regex url)
        {
            throw new NotImplementedException();
        }

        public IFrame FrameByUrl(Func<string, bool> url)
        {
            throw new NotImplementedException();
        }

        public IFrameLocator FrameLocator(string selector)
        {
            return Page.FrameLocator(selector);
        }

        public async Task<string> GetAttributeAsync(string selector, string name, PageGetAttributeOptions options = null)
        {
            return await Page.GetAttributeAsync(selector, name, options);
        }

        public Task<IResponse> GoBackAsync(PageGoBackOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> GoForwardAsync(PageGoForwardOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> GotoAsync(string url, PageGotoOptions options = null)
        {
            ConsoleLogging.WriteLine($"Go to {url}");
            return Page.GotoAsync(url, options);
        }

        public Task HoverAsync(string selector, PageHoverOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<string> InnerHTMLAsync(string selector, PageInnerHTMLOptions options = null)
        {
            throw new NotImplementedException();
        }

        public async Task<string> InnerTextAsync(string selector, PageInnerTextOptions options = null)
        {
            return await Page.InnerTextAsync(selector,options);
        }

        public async Task<string> InputValueAsync(string selector, PageInputValueOptions options = null)
        {
            return await Page.InputValueAsync(selector, options);
        }

        public Task<bool> IsCheckedAsync(string selector, PageIsCheckedOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsDisabledAsync(string selector, PageIsDisabledOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEditableAsync(string selector, PageIsEditableOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEnabledAsync(string selector, PageIsEnabledOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsHiddenAsync(string selector, PageIsHiddenOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsVisibleAsync(string selector, PageIsVisibleOptions options = null)
        {
            return Page.IsVisibleAsync(selector, options);
        }

        public ILocator Locator(string selector, PageLocatorOptions options = null)
        {
            return Page.Locator(selector, options);
        }

        public Task<IPage> OpenerAsync()
        {
            throw new NotImplementedException();
        }

        public Task PauseAsync()
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> PdfAsync(PagePdfOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task PressAsync(string selector, string key, PagePressOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<IElementHandle>> QuerySelectorAllAsync(string selector)
        {
            throw new NotImplementedException();
        }

        public Task<IElementHandle> QuerySelectorAsync(string selector, PageQuerySelectorOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> ReloadAsync(PageReloadOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task RouteAsync(string url, Action<IRoute> handler, PageRouteOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task RouteAsync(Regex url, Action<IRoute> handler, PageRouteOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task RouteAsync(Func<string, bool> url, Action<IRoute> handler, PageRouteOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IConsoleMessage> RunAndWaitForConsoleMessageAsync(Func<Task> action, PageRunAndWaitForConsoleMessageOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IDownload> RunAndWaitForDownloadAsync(Func<Task> action, PageRunAndWaitForDownloadOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IFileChooser> RunAndWaitForFileChooserAsync(Func<Task> action, PageRunAndWaitForFileChooserOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> RunAndWaitForNavigationAsync(Func<Task> action, PageRunAndWaitForNavigationOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IPage> RunAndWaitForPopupAsync(Func<Task> action, PageRunAndWaitForPopupOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IRequest> RunAndWaitForRequestAsync(Func<Task> action, string urlOrPredicate, PageRunAndWaitForRequestOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IRequest> RunAndWaitForRequestAsync(Func<Task> action, Regex urlOrPredicate, PageRunAndWaitForRequestOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IRequest> RunAndWaitForRequestAsync(Func<Task> action, Func<IRequest, bool> urlOrPredicate, PageRunAndWaitForRequestOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IRequest> RunAndWaitForRequestFinishedAsync(Func<Task> action, PageRunAndWaitForRequestFinishedOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> RunAndWaitForResponseAsync(Func<Task> action, string urlOrPredicate, PageRunAndWaitForResponseOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> RunAndWaitForResponseAsync(Func<Task> action, Regex urlOrPredicate, PageRunAndWaitForResponseOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> RunAndWaitForResponseAsync(Func<Task> action, Func<IResponse, bool> urlOrPredicate, PageRunAndWaitForResponseOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IWebSocket> RunAndWaitForWebSocketAsync(Func<Task> action, PageRunAndWaitForWebSocketOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IWorker> RunAndWaitForWorkerAsync(Func<Task> action, PageRunAndWaitForWorkerOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> ScreenshotAsync(PageScreenshotOptions options = null)
        {
            ConsoleLogging.WriteLine("Take a screenshot");
            return Page.ScreenshotAsync(options);
        }

        public Task ElementScreenshotAsync(string element, string imagePath)
        {
            ConsoleLogging.WriteLine("Take a element screenshot");
            return Page.Locator(element).ScreenshotAsync(new LocatorScreenshotOptions { Path = imagePath });
        }

        public Task<IReadOnlyList<string>> SelectOptionAsync(string selector, string values, PageSelectOptionOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<string>> SelectOptionAsync(string selector, IElementHandle values, PageSelectOptionOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<string>> SelectOptionAsync(string selector, IEnumerable<string> values, PageSelectOptionOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<string>> SelectOptionAsync(string selector, SelectOptionValue values, PageSelectOptionOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<string>> SelectOptionAsync(string selector, IEnumerable<IElementHandle> values, PageSelectOptionOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<string>> SelectOptionAsync(string selector, IEnumerable<SelectOptionValue> values, PageSelectOptionOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task SetCheckedAsync(string selector, bool checkedState, PageSetCheckedOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task SetContentAsync(string html, PageSetContentOptions options = null)
        {
            throw new NotImplementedException();
        }

        public void SetDefaultNavigationTimeout(float timeout)
        {
            throw new NotImplementedException();
        }

        public void SetDefaultTimeout(float timeout)
        {
            throw new NotImplementedException();
        }

        public Task SetExtraHTTPHeadersAsync(IEnumerable<KeyValuePair<string, string>> headers)
        {
            throw new NotImplementedException();
        }

        public Task SetInputFilesAsync(string selector, string files, PageSetInputFilesOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task SetInputFilesAsync(string selector, IEnumerable<string> files, PageSetInputFilesOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task SetInputFilesAsync(string selector, FilePayload files, PageSetInputFilesOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task SetInputFilesAsync(string selector, IEnumerable<FilePayload> files, PageSetInputFilesOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task SetViewportSizeAsync(int width, int height)
        {
            throw new NotImplementedException();
        }

        public Task TapAsync(string selector, PageTapOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<string> TextContentAsync(string selector, PageTextContentOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<string> TitleAsync()
        {
            return Page.TitleAsync();
        }

        public Task TypeAsync(string selector, string text, PageTypeOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task UncheckAsync(string selector, PageUncheckOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task UnrouteAsync(string url, Action<IRoute> handler = null)
        {
            throw new NotImplementedException();
        }

        public Task UnrouteAsync(Regex url, Action<IRoute> handler = null)
        {
            throw new NotImplementedException();
        }

        public Task UnrouteAsync(Func<string, bool> url, Action<IRoute> handler = null)
        {
            throw new NotImplementedException();
        }

        public Task<IConsoleMessage> WaitForConsoleMessageAsync(PageWaitForConsoleMessageOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IDownload> WaitForDownloadAsync(PageWaitForDownloadOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IFileChooser> WaitForFileChooserAsync(PageWaitForFileChooserOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IJSHandle> WaitForFunctionAsync(string expression, object arg = null, PageWaitForFunctionOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task WaitForLoadStateAsync(LoadState? state = null, PageWaitForLoadStateOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> WaitForNavigationAsync(PageWaitForNavigationOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IPage> WaitForPopupAsync(PageWaitForPopupOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IRequest> WaitForRequestAsync(string urlOrPredicate, PageWaitForRequestOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IRequest> WaitForRequestAsync(Regex urlOrPredicate, PageWaitForRequestOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IRequest> WaitForRequestAsync(Func<IRequest, bool> urlOrPredicate, PageWaitForRequestOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IRequest> WaitForRequestFinishedAsync(PageWaitForRequestFinishedOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> WaitForResponseAsync(string urlOrPredicate, PageWaitForResponseOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> WaitForResponseAsync(Regex urlOrPredicate, PageWaitForResponseOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> WaitForResponseAsync(Func<IResponse, bool> urlOrPredicate, PageWaitForResponseOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IElementHandle> WaitForSelectorAsync(string selector, PageWaitForSelectorOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task WaitForTimeoutAsync(float timeout)
        {
            throw new NotImplementedException();
        }

        public Task WaitForURLAsync(string url, PageWaitForURLOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task WaitForURLAsync(Regex url, PageWaitForURLOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task WaitForURLAsync(Func<string, bool> url, PageWaitForURLOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IWebSocket> WaitForWebSocketAsync(PageWaitForWebSocketOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<IWorker> WaitForWorkerAsync(PageWaitForWorkerOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task RouteFromHARAsync(string har, PageRouteFromHAROptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task RouteAsync(string url, Func<IRoute, Task> handler, PageRouteOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task RouteAsync(Regex url, Func<IRoute, Task> handler, PageRouteOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task RouteAsync(Func<string, bool> url, Func<IRoute, Task> handler, PageRouteOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task UnrouteAsync(string url, Func<IRoute, Task> handler)
        {
            throw new NotImplementedException();
        }

        public Task UnrouteAsync(Regex url, Func<IRoute, Task> handler)
        {
            throw new NotImplementedException();
        }

        public Task UnrouteAsync(Func<string, bool> url, Func<IRoute, Task> handler)
        {
            throw new NotImplementedException();
        }
    }
}

