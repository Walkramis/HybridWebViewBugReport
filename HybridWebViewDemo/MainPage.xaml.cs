using System.Diagnostics;
using System.Text.Json.Serialization;

namespace HybridWebViewDemo;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
        hybridWebView.SetInvokeJavaScriptTarget(this);
    }

    private async void OnInvokeJSMethodButtonClicked(object sender, EventArgs e)
    {
#if ANDROID
        hybridWebView.EvaluateJavaScriptAsync("window.location = 'https://0.0.0.1/index.html#1234';");
#elif IOS
        hybridWebView.EvaluateJavaScriptAsync("window.location = 'app://0.0.0.1/index.html#1234';");
#endif
    }

    private async void OnInvokeAsyncJSMethodButtonClicked(object sender, EventArgs e)
    {
#if ANDROID
        hybridWebView.EvaluateJavaScriptAsync("window.location = 'https://0.0.0.1/index.html?1234';");
#elif IOS
        hybridWebView.EvaluateJavaScriptAsync("window.location = 'app://0.0.0.1/index.html?1234';");
#endif
    }

    private void hybridWebView_RawMessageReceived(object sender, HybridWebViewRawMessageReceivedEventArgs e)
    {
        Dispatcher.Dispatch(() => editor.Text += Environment.NewLine + e.Message);
    }
}
