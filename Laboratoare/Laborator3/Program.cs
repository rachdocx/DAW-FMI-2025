var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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


//concatenare
app.MapControllerRoute(
    name: "Concatenare",

    pattern: "Concatenare/{a}/{b}",

    defaults: new { controller = "Examples", action = "concatenare" }

).WithStaticAssets();
//produs
app.MapControllerRoute(
    name: "Produs",

    pattern: "Produs/{a}/{b?}",

    defaults: new { controller = "Examples", action = "concatenare" }
).WithStaticAssets();
//operatie
app.MapControllerRoute(
    name: "Operatie",

    pattern: "Operatie/{a?}/{b?}/{op?}",

    defaults: new { controller = "Examples", action = "operatie" }
).WithStaticAssets();
//student EXERCITIUL 2 /Students/Index
app.MapControllerRoute(
    name: "StudentsIndex",
    pattern: "{controller=Students}/{action=Index}").WithStaticAssets();

app.MapControllerRoute(
    name: "StudentsCreate",
    pattern: "students/new",
    defaults: new {controller ="Students", action = "Create"}

    ).WithStaticAssets();
//VARIANTA 2 
app.MapControllerRoute(
    name: "StudentsAll",
pattern: "students/all",
defaults: new { controller = "Students", action = "Index" }

).WithStaticAssets();


app.MapControllerRoute(

name: "StudentsShow",
pattern: "students/show/{id?}",
defaults: new { controller = "Students", action = "Show" }

).WithStaticAssets();

app.MapControllerRoute(

name: "StudentsEdit",
pattern: "students/edit/{id?}",
defaults: new { controller = "Students", action = "Edit" }

).WithStaticAssets();

app.MapControllerRoute(

name: "StudentsDelete",
pattern: "students/delete/{id?}",
defaults: new { controller = "Students", action = "Delete" }

).WithStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
