var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    // Thông báo lỗi binding bằng tiếng Việt
    var msg = options.ModelBindingMessageProvider;
    msg.SetValueMustNotBeNullAccessor(_ => "Vui lòng nhập giá trị");
    msg.SetMissingBindRequiredValueAccessor(f => $"Thiếu giá trị cho {f}");
    msg.SetMissingKeyOrValueAccessor(() => "Vui lòng nhập giá trị");
    msg.SetAttemptedValueIsInvalidAccessor((v, f) => $"Giá trị '{v}' không hợp lệ cho {f}");
    msg.SetUnknownValueIsInvalidAccessor(f => $"Giá trị không hợp lệ cho {f}");
    msg.SetValueIsInvalidAccessor(v => $"Giá trị '{v}' không hợp lệ");
    msg.SetValueMustBeANumberAccessor(f => $"{f} phải là số");
    msg.SetNonPropertyAttemptedValueIsInvalidAccessor(v => $"Giá trị '{v}' không hợp lệ");
    msg.SetNonPropertyUnknownValueIsInvalidAccessor(() => "Giá trị không hợp lệ");
    msg.SetNonPropertyValueMustBeANumberAccessor(() => "Giá trị phải là số");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
