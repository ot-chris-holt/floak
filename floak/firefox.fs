
module firefox

open OpenQA.Selenium.Firefox
open OpenQA.Selenium
open OpenQA.Selenium.Support.UI
open System

let browser = new FirefoxDriver()

let url (u : string) = browser.Navigate().GoToUrl(u)

let write (cssSelector : string) (text : string) = 
    let element = browser.FindElement(By.CssSelector(cssSelector))
    element.SendKeys(text)

let read (cssSelector : string) =    
    let element = browser.FindElement(By.CssSelector(cssSelector))
    if element.TagName = "input" then
        element.GetAttribute("value")
    else
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

let (==) element value =
    let wait = new WebDriverWait(browser, TimeSpan.FromSeconds(3.0))
    try
        wait.Until(fun b -> (read element) = value) |> ignore
    with
        | :? Exception -> ()

    equals value (read element)
    
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