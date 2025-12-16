using ArticlesApp.Models;
using ArticlesAppLab6.Data;
using Microsoft.AspNetCore.Mvc;

namespace ArticlesAppLab6.Controllers
{
    public class CommentsController(ApplicationDbContext context) : Controller
    {
         private readonly ApplicationDbContext db = context;


        
    }
}