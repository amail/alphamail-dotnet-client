/*
The MIT License

Copyright (c) 2011 Comfirm <http://www.comfirm.se/>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using System;
using Comfirm.AlphaMail.Services.Client.Entities;
using Comfirm.AlphaMail.Services.Client.Exceptions;
using Comfirm.AlphaMail.Services.Client;

namespace Comfirm.AlphaMail.HelloWorldConsole
{
    /// <summary>
    /// Hello World-message with data that we've defined in our template
    /// </summary>
    public class HelloWorldMessage
    {
        /// <summary>
        /// Represents the <# payload.Message #> in our template
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Represents the <# payload.SomeOtherMessage #> in our template
        /// </summary>
        public string SomeOtherMessage { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Step #1: Let's start by entering the web service URL and the API-token you've been provided
            // If you haven't gotten your API-token yet. Log into AlphaMail or contact support at 'support@comfirm.se'.
            IEmailService emailService = new AlphaMailEmailService()
                .SetServiceUrl("http://api.amail.io/v2/")
                .SetApiToken("YOUR-ACCOUNT-API-TOKEN-HERE");

            // Step #2: Let's fill in the gaps for the variables (stuff) we've used in our template
            var message = new HelloWorldMessage()
            {
                Message = "Hello world like a boss!",
                SomeOtherMessage = "And to the rest of the world! Chíkmàa! مرحبا! नमस्ते! Dumelang!"
            };

            // Step #3: Let's set up everything that is specific for delivering this email
            var payload = new EmailMessagePayload()
                .SetProjectId(12345) // The id of the project your want to send with
                .SetSender(new EmailContact("Sender Company Name", "your-sender-email@your-sender-domain.com"))
                .SetReceiver(new EmailContact("Joe E. Receiver", "email-of-receiver@comfirm.se"))
                .SetBodyObject(message);
            
            try
            {
                // Step #4: Haven't we waited long enough. Let's send this!
                var response = emailService.Queue(payload);
                
                // Step #5: Pop the champagné! We got here which mean that the request was sent successfully and the email is on it's way!
                Console.WriteLine("Successfully queued message with id '{0}' (you can use this ID to get more details about the delivery)", response.Result);
            }
            // Oh heck. Something went wrong. But don't stop here.
            // If you haven't solved it yourself. Just contact our brilliant support and they will help you.
            catch (AlphaMailValidationException exception)
            {
                // Example: Handle request specific error code here
                if (exception.Response.ErrorCode == 3)
                {
                    // Example: Print a nice message to the user.
                }
                else
                {
                    // Something in the input was wrong. Probably good to double double-check!
                    Console.WriteLine("Validation error: {0} ({1})", exception.Response.Message, exception.Response.ErrorCode);
                }
            }
            catch (AlphaMailAuthorizationException exception)
            {
                // Ooops! You've probably just entered the wrong API-token.
                Console.WriteLine("Authentication error: {0} ({1})", exception.Response.Message, exception.Response.ErrorCode);
            }
            catch (AlphaMailInternalException exception)
            {
                // Not that it is going to happen.. Right :-)
                Console.WriteLine("Internal error: {0} ({1})", exception.Response.Message, exception.Response.ErrorCode);
            }
            catch (AlphaMailServiceException exception)
            {
                // Most likely your internet connection that is down. We are covered for most things except "multi-data-center-angry-server-bashing-monkeys" (remember who coined it) or.. nuclear bombs.
                // If one blew. Well.. It's just likely that our servers are down.
                Console.WriteLine("An error (probably related to connection) occurred: {0}", exception);
            }

            // Writing to console like a boss
            Console.WriteLine("\n\tIn doubt or experiencing problems?\n" +
                "\tPlease email our support at 'support@comfirm.se'");

            // This was exhausting. Let's grab a beer.
            Console.WriteLine("\nPress any key to terminate..");
            Console.ReadLine();
        }
    }
}
