﻿
module firefox

open OpenQA.Selenium.Firefox
open OpenQA.Selenium

let browser = new FirefoxDriver()

let url (u : string) = browser.Navigate().GoToUrl(u)

let write (cssSelector : string) (text : string) = 
    let element = browser.FindElement(By.CssSelector(cssSelector))
    element.SendKeys(text)

let read (cssSelector : string) = 
    let element = browser.FindElement(By.CssSelector(cssSelector))
    element.Text

let clear (cssSelector : string) = 
    let element = browser.FindElement(By.CssSelector(cssSelector))
    element.Clear()
    
let click (cssSelector : string) = 
    let element = browser.FindElement(By.CssSelector(cssSelector))
    element.Click()

let title _ = browser.Title

let quit _ = browser.Quit()

let equals value1 value2 =
    if (value1 = value2) then
        System.Console.WriteLine("equality check passed.");
    else
        System.Console.WriteLine("equality check failed.  expected: {0}, got: {1}", value1, value2);
    ()
    
let contains (value1 : string) (value2 : string) =
    if (value2.Contains(value1) = true) then
        System.Console.WriteLine("contains check passed.");
    else
        System.Console.WriteLine("contains check failed.  {0} does not contain {1}", value2, value1);        
    ()

let describe (text : string) =
    System.Console.WriteLine(text);
    ()

let currentUrl _ =
    browser.Url