using DemoNorthwindWithEF.Bussiness.Mapping;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.Bussiness.Repository;
using ProjectPRN_FAP.DataAccess.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped(typeof(ISemesterRepository), typeof(SemesterRepository));
builder.Services.AddScoped(typeof(IClassRepository), typeof(ClassRepository));
builder.Services.AddScoped(typeof(ISubjectRepository), typeof(SubjectRepository));
builder.Services.AddScoped(typeof(IGradeRepository), typeof(GradeRepository));
builder.Services.AddScoped(typeof(ISubjectGradeRepository), typeof(SubjectGradeRepository));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddScoped(typeof(IStudentRepository), typeof(StudentRepository));
builder.Services.AddScoped(typeof(ITeacherRepository), typeof(TeacherRepository));
builder.Services.AddScoped(typeof(IClassSubjectRepository), typeof(ClassSubjectRepository));
builder.Services.AddScoped(typeof(IStudentClassSubjectRepository), typeof(StudentClassSubjectRepository));
builder.Services.AddScoped(typeof(ITranscriptRepository), typeof(TranscriptRepository));
builder.Services.AddScoped(typeof(IDetailScoreRepository), typeof(DetailScoreRepository));
builder.Services.AddScoped(typeof(IClassGradeRepository), typeof(ClassGradeRepository));
builder.Services.AddScoped(typeof(IClassTranscriptRepository), typeof(ClassTranscriptRepository));

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnectString")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddRazorPages();
builder.Services.AddDbContext<DataContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnectString")));

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Common/Login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
