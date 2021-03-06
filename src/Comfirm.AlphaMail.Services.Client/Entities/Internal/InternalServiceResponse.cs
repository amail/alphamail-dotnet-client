﻿/*
The MIT License

Copyright (c) Robin Orheden, 2013 <http://amail.io/>

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

using System.Runtime.Serialization;

namespace Comfirm.AlphaMail.Services.Client.Entities.Internal
{
    [DataContract]
    internal class InternalServiceResponse<TResult>
    {
        [DataMember]
        public int error_code { get; set; }

        [DataMember]
        public string message { get; set; }

        [DataMember]
        public TResult result { get; set; }

        internal static ServiceResponse<TResult> Map(InternalServiceResponse<TResult> response)
        {
            return new ServiceResponse<TResult>()
            {
                ErrorCode = response.error_code,
                Message = response.message,
                Result = response.result
            };
        }
    }
}
