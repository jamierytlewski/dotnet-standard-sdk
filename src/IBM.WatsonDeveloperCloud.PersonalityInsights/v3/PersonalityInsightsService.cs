﻿/**
* Copyright 2017 IBM Corp. All Rights Reserved.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

using System;
using System.Text;
using IBM.WatsonDeveloperCloud.Http;
using IBM.WatsonDeveloperCloud.PersonalityInsights.v3.Model;
using IBM.WatsonDeveloperCloud.Service;
using System.Runtime.ExceptionServices;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace IBM.WatsonDeveloperCloud.PersonalityInsights.v3
{
    public class PersonalityInsightsService : WatsonService, IPersonalityInsightsService
    {
        const string SERVICE_NAME = "personality_insights";

        const string URL = "https://gateway.watsonplatform.net/personality-insights/api";
        const string PATH_GET_PROFILES = "/v3/profile";

        public PersonalityInsightsService()
            : base(SERVICE_NAME, URL)
        {
            if (!string.IsNullOrEmpty(this.Endpoint))
                this.Endpoint = URL;
        }

        public PersonalityInsightsService(string userName, string password)
            : this()
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException(nameof(userName));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            this.SetCredential(userName, password);
        }

        public PersonalityInsightsService(IClient httpClient)
            : this()
        {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));

            this.Client = httpClient;
        }

        public Profile GetProfile(ProfileOptions options)
        {
            Profile result = null;

            try
            {
                Encoding enc = null;

                switch (options.ContentType)
                {
                    case HttpMediaType.TEXT_HTML:
                    case HttpMediaType.TEXT_PLAIN:
                        enc = Encoding.ASCII;
                        break;

                    case HttpMediaType.APPLICATION_JSON:
                        enc = Encoding.UTF8;
                        break;
                }

                //int bodySize = enc.GetByteCount(options.Text) / 1024 / 1024;

                ByteArrayContent content = new ByteArrayContent(Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(options.ContentItems)));
                
                result =
                     this.Client.WithAuthentication(UserName, Password)
                                .PostAsync($"{this.Endpoint}{PATH_GET_PROFILES}")
                                .WithArgument("version", "2016-10-20")
                                .WithHeader("Content-Type", options.ContentType)
                                .WithHeader("Content-Language", options.Language)
                                .WithHeader("Accept", options.Accept)
                                .WithHeader("Accept-Language", options.AcceptLanguage)
                                .WithArgument("raw_scores", options.IncludeRaw)
                                .WithArgument("csv_headers", options.CsvHeaders)
                                .WithArgument("consumption_preferences", options.ConsumptionPreferences)
                                .WithBodyContent(content)
                                .As<Profile>()
                                .Result;
            }
            catch (AggregateException ae)
            {
                throw ae.Flatten();
            }

            return result;
        }
    }
}