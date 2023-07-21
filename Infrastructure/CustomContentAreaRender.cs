using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServer.Web.Mvc.Html;

namespace EpiserverTraining.Infrastructure
{
    //public class CustomContentAreaRender : ContentAreaRenderer
    //{

    //}
    //  [ServiceConfiguration(typeof(ContentAreaRenderer), Lifecycle = ServiceInstanceScope.Transient)]
    public  class ContentAreaRenderer : EPiServer.Web.Mvc.Html.ContentAreaRenderer
    {

        private readonly IContentAreaItemAttributeAssembler _attributeAssembler;
        private readonly IContentRenderer _contentRenderer;
        private readonly IContentRepository _contentRepository;
        private readonly TemplateResolver _templateResolver;

        public ContentAreaRenderer(IContentRenderer contentRenderer, TemplateResolver templateResolver, IContentAreaItemAttributeAssembler attributeAssembler, IContentRepository contentRepository)

        {
            _contentRenderer = contentRenderer;
            _templateResolver = templateResolver;
            _attributeAssembler = attributeAssembler;
            _contentRepository = contentRepository;
        }
        protected override void RenderContentAreaItem(HtmlHelper htmlHelper, ContentAreaItem contentAreaItem, string templateTag, string htmlTag, string cssClass)
        {
            var dictionary = new Dictionary<string, object>();
            dictionary["childrencustomtagname"] = htmlTag;
            dictionary["childrencssclass"] = cssClass;
            dictionary["tag"] = templateTag;

            dictionary = contentAreaItem.RenderSettings.Concat(
                 (
                 from r in dictionary
                 where !contentAreaItem.RenderSettings.ContainsKey(r.Key)
                 select r
                 )
             ).ToDictionary(r => r.Key, r => r.Value);

            htmlHelper.ViewBag.RenderSettings = dictionary;
            var content = contentAreaItem.GetContent(_contentRepository);

            if (content != null)
            {
                using (new ContentAreaContext(htmlHelper.ViewContext.RequestContext, content.ContentLink))
                {
                    var templateModel = ResolveTemplate(htmlHelper, content, templateTag);
                    if ((templateModel != null) || IsInEditMode(htmlHelper))
                    {
                        if (IsInEditMode(htmlHelper))
                        {
                            var tagBuilder = new TagBuilder(htmlTag);
                            AddNonEmptyCssClass(tagBuilder, cssClass);
                            tagBuilder.MergeAttributes<string, string>(
                                _attributeAssembler.GetAttributes(
                                    contentAreaItem, IsInEditMode(htmlHelper), (bool)(templateModel != null)));
                            BeforeRenderContentAreaItemStartTag(tagBuilder, contentAreaItem);
                            htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));
                            htmlHelper.RenderContentData(content, true, templateModel, _contentRenderer);
                            htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.EndTag));
                        }
                        else
                        {
                            htmlHelper.RenderContentData(content, true, templateModel, _contentRenderer);
                        }
                    }
                }
            }
        }

        private void RenderEditorView()
        {

        }

        protected override bool ShouldRenderWrappingElement(HtmlHelper htmlHelper)
        {
            return false;
        }
    }


}