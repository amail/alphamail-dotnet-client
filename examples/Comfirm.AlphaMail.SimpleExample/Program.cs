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
using Comfirm.AlphaMail.Services.Client;
using Comfirm.AlphaMail.Services.Client.Entities;
using Comfirm.AlphaMail.Services.Client.Exceptions;

namespace Comfirm.AlphaMail.SimpleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailService = new AlphaMailEmailService("YOUR-ACCOUNT-API-TOKEN-HERE");

            var message = new
            {
                Message = "Hello world like a boss!",
                SomeOtherMessage = "And to the rest of the world! Chíkmàa! مرحبا! नमस्ते! Dumelang!"
            };

            var payload = new EmailMessagePayload()
                .SetProjectId(12345) // The id of the project your want to send with
                .SetSender(new EmailContact("Sender Company Name", "your-sender-email@your-sender-domain.com"))
                .SetReceiver(new EmailContact("Joe E. Receiver", "email-of-receiver@comfirm.se"))
                .SetBodyObject(message);

            try
            {
                var response = emailService.Queue(payload);
                Console.WriteLine("Mail successfully sent! ID = {0}", response.Result);
            }
            catch (AlphaMailServiceException exception)
            {
                Console.WriteLine("Error! {0} ({1})", exception.Message, exception.GetErrorCode());
            }
        }
    }
}
