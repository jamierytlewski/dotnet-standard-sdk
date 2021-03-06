/**
* Copyright 2018 IBM Corp. All Rights Reserved.
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

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBM.WatsonDeveloperCloud.PersonalityInsights.v3.Model
{
    /// <summary>
    /// ContentItem.
    /// </summary>
    public class ContentItem : BaseModel
    {
        /// <summary>
        /// The MIME type of the content. The default is plain text. The tags are stripped from HTML content before it
        /// is analyzed; plain text is processed as submitted.
        /// </summary>
        /// <value>
        /// The MIME type of the content. The default is plain text. The tags are stripped from HTML content before it
        /// is analyzed; plain text is processed as submitted.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ContenttypeEnum
        {
            
            /// <summary>
            /// Enum TEXT_PLAIN for text/plain
            /// </summary>
            [EnumMember(Value = "text/plain")]
            TEXT_PLAIN,
            
            /// <summary>
            /// Enum TEXT_HTML for text/html
            /// </summary>
            [EnumMember(Value = "text/html")]
            TEXT_HTML
        }

        /// <summary>
        /// The language identifier (two-letter ISO 639-1 identifier) for the language of the content item. The default
        /// is `en` (English). Regional variants are treated as their parent language; for example, `en-US` is
        /// interpreted as `en`. A language specified with the **Content-Type** parameter overrides the value of this
        /// parameter; any content items that specify a different language are ignored. Omit the **Content-Type**
        /// parameter to base the language on the most prevalent specification among the content items; again, content
        /// items that specify a different language are ignored. You can specify any combination of languages for the
        /// input and response content.
        /// </summary>
        /// <value>
        /// The language identifier (two-letter ISO 639-1 identifier) for the language of the content item. The default
        /// is `en` (English). Regional variants are treated as their parent language; for example, `en-US` is
        /// interpreted as `en`. A language specified with the **Content-Type** parameter overrides the value of this
        /// parameter; any content items that specify a different language are ignored. Omit the **Content-Type**
        /// parameter to base the language on the most prevalent specification among the content items; again, content
        /// items that specify a different language are ignored. You can specify any combination of languages for the
        /// input and response content.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum LanguageEnum
        {
            
            /// <summary>
            /// Enum AR for ar
            /// </summary>
            [EnumMember(Value = "ar")]
            AR,
            
            /// <summary>
            /// Enum EN for en
            /// </summary>
            [EnumMember(Value = "en")]
            EN,
            
            /// <summary>
            /// Enum ES for es
            /// </summary>
            [EnumMember(Value = "es")]
            ES,
            
            /// <summary>
            /// Enum JA for ja
            /// </summary>
            [EnumMember(Value = "ja")]
            JA,
            
            /// <summary>
            /// Enum KO for ko
            /// </summary>
            [EnumMember(Value = "ko")]
            KO
        }

        /// <summary>
        /// The MIME type of the content. The default is plain text. The tags are stripped from HTML content before it
        /// is analyzed; plain text is processed as submitted.
        /// </summary>
        [JsonProperty("contenttype", NullValueHandling = NullValueHandling.Ignore)]
        public ContenttypeEnum? Contenttype { get; set; }
        /// <summary>
        /// The language identifier (two-letter ISO 639-1 identifier) for the language of the content item. The default
        /// is `en` (English). Regional variants are treated as their parent language; for example, `en-US` is
        /// interpreted as `en`. A language specified with the **Content-Type** parameter overrides the value of this
        /// parameter; any content items that specify a different language are ignored. Omit the **Content-Type**
        /// parameter to base the language on the most prevalent specification among the content items; again, content
        /// items that specify a different language are ignored. You can specify any combination of languages for the
        /// input and response content.
        /// </summary>
        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public LanguageEnum? Language { get; set; }
        /// <summary>
        /// The content that is to be analyzed. The service supports up to 20 MB of content for all `ContentItem`
        /// objects combined.
        /// </summary>
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }
        /// <summary>
        /// A unique identifier for this content item.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        /// <summary>
        /// A timestamp that identifies when this content was created. Specify a value in milliseconds since the UNIX
        /// Epoch (January 1, 1970, at 0:00 UTC). Required only for results that include temporal behavior data.
        /// </summary>
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public long? Created { get; set; }
        /// <summary>
        /// A timestamp that identifies when this content was last updated. Specify a value in milliseconds since the
        /// UNIX Epoch (January 1, 1970, at 0:00 UTC). Required only for results that include temporal behavior data.
        /// </summary>
        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public long? Updated { get; set; }
        /// <summary>
        /// The unique ID of the parent content item for this item. Used to identify hierarchical relationships between
        /// posts/replies, messages/replies, and so on.
        /// </summary>
        [JsonProperty("parentid", NullValueHandling = NullValueHandling.Ignore)]
        public string Parentid { get; set; }
        /// <summary>
        /// Indicates whether this content item is a reply to another content item.
        /// </summary>
        [JsonProperty("reply", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Reply { get; set; }
        /// <summary>
        /// Indicates whether this content item is a forwarded/copied version of another content item.
        /// </summary>
        [JsonProperty("forward", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Forward { get; set; }
    }

}
