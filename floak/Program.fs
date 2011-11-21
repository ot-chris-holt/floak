module borrowedgames

open firefox
open register
 
describe "login fails when user is not registered"
url "http://localhost:3000/Account/LogOn"
write "#Email" "lefthandedgoat@gmail.com"
write "#Password" "mypassword1"
click "input[value='login']"
(read "#main") |> contains "Login failed."

describe "clicking register takes you to the registration page"
url "http://localhost:3000/Account/LogOn"
click "a[href='/Account/Register']"
(currentUrl ()) |> equals registerUrl

describe "registration fails with error when you dont type an email"
url registerUrl
click register
(currentUrl ()) |> equals registerUrl
(read "#main") |> contains "Email is required."

describe "registration fails with error when you dont type a valid email"
url registerUrl
write email "aldfjalfdjalsjdf"
click register
(currentUrl ()) |> equals registerUrl
(read "#main") |> contains "Email is invalid."

describe "registration fails with error when you dont type a password"
url registerUrl
write email "lefthandedgoat@gmail.com"
click register
(currentUrl ()) |> equals registerUrl
(read "#main") |> contains "Password is required."

describe "registration fails with error when you dont type matching paswords"
url registerUrl
write email "lefthandedgoat@gmail.com"
write password "mypassword1"
write passwordConfirmation "mypassword2"
click register
(currentUrl ()) |> equals registerUrl
(read "#main") |> contains "Passwords do not match."

describe "registration completes when you enter valid information"
url registerUrl
write email "lefthandedgoat@gmail.com"
write password "mypassword1"
write passwordConfirmation "mypassword1"
click register
(currentUrl ()) |> equals "http://localhost:3000/"

describe "registration fails when you try to register with an existing email address"
url registerUrl
write email "lefthandedgoat@gmail.com"
write password "mypassword1"
write passwordConfirmation "mypassword1"
click register
(currentUrl ()) |> equals registerUrl
(read "#main") |> contains "Email is unavailable."

quit ()

System.Console.ReadKey()