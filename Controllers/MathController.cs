using System;
using Microsoft.AspNetCore.Mvc;
using MathWizard.Models;

namespace MathWizard.Controllers
{
    public class MathController : Controller
    {


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Wizard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoCalculation([FromForm] MathOperation mathOperation)
        {
            if(ModelState.IsValid){
            }
            else{
                
            }

            if(mathOperation == null)
            {
                return View("Error");
            }
            else
            {
                switch(mathOperation.Operator){
                    case "Add":
                        mathOperation.Result = 
                        mathOperation.LeftOperand + mathOperation.RightOperand;
                        break;
                    
                    case "Subtract":
                        mathOperation.Result = 
                        mathOperation.LeftOperand - mathOperation.RightOperand;                
                        break;

                    case "Multiply":
                        mathOperation.Result = 
                        mathOperation.LeftOperand * mathOperation.RightOperand;                
                        break;
                    
                    case "Divide":
                        mathOperation.Result = 
                        mathOperation.LeftOperand / mathOperation.RightOperand;                
                        break;

                    case "Modulus":
                        mathOperation.Result = 
                        mathOperation.LeftOperand % mathOperation.RightOperand;                
                        break;

                    default:
                        MathOperation op = new MathOperation();
                        op.LeftOperand = mathOperation.LeftOperand;
                        op.LeftOperand = mathOperation.RightOperand;
                        op.Operator = mathOperation.Operator;
                        op.Result = 0;
                        return View(op);
                        //break;
                        
                    
                }
            }
            return View(mathOperation);
        }

        public IActionResult AnotherWizard()
        {
            return View();
        }

        public IActionResult DoMathOp(MathOp mathOp)
        {
            if(ModelState.IsValid){

                switch(mathOp.Operator){
                    case "Plus":
                        mathOp.Result = 
                        mathOp.LeftOperand + mathOp.RightOperand;
                        break;
                    
                    case "Minus":
                        mathOp.Result = 
                        mathOp.LeftOperand - mathOp.RightOperand;                
                        break;

                    case "Times":
                        mathOp.Result = 
                        mathOp.LeftOperand * mathOp.RightOperand;                
                        break;
                    
                    case "Divided By":
                        if(mathOp.RightOperand == 0)
                        {
                            return View("Error");
                        }                    
                        mathOp.Result = 
                        mathOp.LeftOperand / mathOp.RightOperand;                
                        break;

                    case "Modulus":
                        mathOp.Result = 
                        mathOp.LeftOperand % mathOp.RightOperand;                
                        break;

                    default:
                        MathOp op = new MathOp();
                        op.LeftOperand = mathOp.LeftOperand;
                        op.RightOperand = mathOp.RightOperand;
                        op.Operator = mathOp.Operator;
                        op.Result = -999;
                        return View(op);                        
                }                
            }
            else
            {
                return View("Error");
            }

            return View(mathOp);
        }
    }
}