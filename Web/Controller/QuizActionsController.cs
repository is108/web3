using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class QuizActionsController : Controller
    {
        [HttpGet]
        public IActionResult Quiz()
        {
            Operations operations = new Operations();
            return View(operations);
        }

        [HttpPost]
        public IActionResult Quiz(Operations operation, string action)
        {
            if (ModelState.IsValid)
            {
                CorrectAnswers answers = CorrectAnswers.Instance;
                answers.Total += 1;
                if (operation.Check())
                    answers.Correct += 1;
                (answers.Answers).Add(operation);
            }
            else
            {
                ModelState.AddModelError("YourAnswer", "недопустимый формат ответа");
                return View(operation);
            }
            if (action == "Next")
                return View(new Operations());
            return RedirectToAction("QuizResult");
        }

        public IActionResult QuizResult()
        {
            CorrectAnswers answers = CorrectAnswers.Instance;
            ViewBag.Result = answers.Answers;
            ViewData["Correct"] = "" + answers.Correct;
            ViewData["Total"] = "" + answers.Total;
            return View();
        }
    }
}