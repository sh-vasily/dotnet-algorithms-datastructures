using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Sorting;
using Sorting.Core.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.Services.AddSorters();

await builder.Build().RunAsync();