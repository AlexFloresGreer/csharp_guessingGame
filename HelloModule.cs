using Nancy;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace HelloNancy
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
// _________________GET__________________
            Get("/", args =>
            {
               if ( Session["playerSession"] == null)
                {
                    Random rnd = new Random();
                    Session["playerSession"] = (int) rnd.Next(1,101);
                    Console.WriteLine("***Player Session***");
                    Console.WriteLine(Session["playerSession"]);
                    return View["Hello"];
                }
                return View["Hello"];
            });     
// _________________POST__________________

            Post("/formsubmitted", args =>
            {
                int playerInput = Request.Form.playerInput;
                int playerSession = (int) Session["playerSession"];
                    
                if (playerInput > playerSession )
                {
                    ViewBag.high = true;
                    Console.WriteLine("I'm hitting high");
                    return View["Hello"];
                }
                else if ( playerInput < playerSession )
                {
                     ViewBag.low = true;
                     Console.WriteLine("I'm hitting low");
                     return View["Hello"];
                }
                else
                {
                        ViewBag.correct = true;
                        Console.WriteLine("I'm hitting correct");
                        return View["Hello"];      
                };

            });   
        }
    }
}