using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdinCM.Helpers
{
    public static class AriaHelper
    {
        public static void AddAriaSpans(this TagBuilder tagBuilder, string screenReaderText, string ariaHiddenText)
        {
            tagBuilder.Attributes.Add("aria-label", screenReaderText);

            var visibleTextTag = new TagBuilder("span");
            visibleTextTag.Attributes.Add("aria-hidden", "true");
            visibleTextTag.InnerHtml.Append(ariaHiddenText);
            tagBuilder.InnerHtml.AppendHtml(visibleTextTag);

            var screenReaderTag = new TagBuilder("span");
            screenReaderTag.AddCssClass("sr-only");
            screenReaderTag.InnerHtml.Append(screenReaderText);
            tagBuilder.InnerHtml.AppendHtml(screenReaderTag);
        }
    }
}
