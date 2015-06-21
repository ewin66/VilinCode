﻿/*
Copyright (c) 2012 <a href="http://www.gutgames.com">James Craig</a>

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
THE SOFTWARE.*/

#region Usings
using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Text;
using System.Xml.Linq;
#endregion

namespace Utilities.FileFormats.BlogML
{
    /// <summary>
    /// Post class
    /// </summary>
    public class Post
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public Post()
        {
            Authors = new Authors();
            Categories = new Categories();
            Tags = new Tags();
            Comments = new Comments();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Element">Element containing the post info</param>
        public Post(XElement Element)
        {
            Contract.Requires<ArgumentNullException>(Element != null, "Element");
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
            ID = Element.Attribute("id") != null ? Element.Attribute("id").Value : "";
            PostURL = Element.Attribute("post-url") != null ? Element.Attribute("post-url").Value : "";
            DateCreated = Element.Attribute("date-created") != null ? DateTime.Parse(Element.Attribute("date-created").Value, CultureInfo.InvariantCulture) : DateTime.MinValue;
            DateModified = Element.Attribute("date-modified") != null ? DateTime.Parse(Element.Attribute("date-modified").Value, CultureInfo.InvariantCulture) : DateCreated;
            if (Element.Element("title") != null)
                Title = Element.Element("title").Value;
            if (Element.Element("content") != null)
                Content = Element.Element("content").Value;
            if (Element.Element("post-name") != null)
                PostName = Element.Element("post-name").Value;
            if (Element.Element("excerpt") != null)
                Excerpt = Element.Element("excerpt").Value;
            if (Element.Element("authors") != null)
                Authors = new Authors(Element.Element("authors"));
            if (Element.Element("categories") != null)
                Categories = new Categories(Element.Element("categories"));
            if (Element.Element("tags") != null)
                Tags = new Tags(Element.Element("tags"));
            if (Element.Element("comments") != null)
                Comments = new Comments(Element.Element("comments"));
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// ID of the post
        /// </summary>
        public virtual string ID { get; set; }

        /// <summary>
        /// URL of the post
        /// </summary>
        public virtual string PostURL { get; set; }

        /// <summary>
        /// Title of the post
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// Content of the post
        /// </summary>
        public virtual string Content { get; set; }

        /// <summary>
        /// Excerpt of the post
        /// </summary>
        public virtual string Excerpt { get; set; }

        /// <summary>
        /// Name of the post
        /// </summary>
        public virtual string PostName { get; set; }

        /// <summary>
        /// Date the post was created
        /// </summary>
        public virtual DateTime DateCreated { get; set; }

        /// <summary>
        /// Date the post was modified
        /// </summary>
        public virtual DateTime DateModified { get; set; }

        /// <summary>
        /// Authors of the post
        /// </summary>
        public virtual Authors Authors { get; set; }

        /// <summary>
        /// Categories associated with the post
        /// </summary>
        public virtual Categories Categories { get; set; }

        /// <summary>
        /// Tags associated with the post
        /// </summary>
        public virtual Tags Tags { get; set; }

        /// <summary>
        /// Comments associated with the post
        /// </summary>
        public virtual Comments Comments { get; set; }

        #endregion

        #region Overridden Functions

        /// <summary>
        /// Converts the object to a string
        /// </summary>
        /// <returns>The object as a string</returns>
        public override string ToString()
        {
            StringBuilder Builder = new StringBuilder();
            Builder.AppendFormat(CultureInfo.InvariantCulture, "<post id=\"{0}\" date-created=\"{1}\" date-modified=\"{2}\" approved=\"true\" post-url=\"{3}\" type=\"normal\" hasexcerpt=\"true\" views=\"0\" is-published=\"True\">\n", ID, DateCreated.ToString("yyyy-MM-ddThh:mm:ss", CultureInfo.InvariantCulture), DateModified.ToString("yyyy-MM-ddThh:mm:ss", CultureInfo.InvariantCulture), PostURL);
            Builder.AppendFormat(CultureInfo.InvariantCulture, "<title type=\"text\"><![CDATA[{0}]]></title>\n", Title);
            Builder.AppendFormat(CultureInfo.InvariantCulture, "<content type=\"text\"><![CDATA[{0}]]></content>\n", Content);
            Builder.AppendFormat(CultureInfo.InvariantCulture, "<post-name type=\"text\"><![CDATA[{0}]]></post-name>\n", PostName);
            Builder.AppendFormat(CultureInfo.InvariantCulture, "<excerpt type=\"text\"><![CDATA[{0}]]></excerpt>\n", Excerpt);
            Builder.AppendLine(Authors.ToString());
            Builder.AppendLine(Categories.ToString());
            Builder.AppendLine(Tags.ToString());
            Builder.AppendLine(Comments.ToString());
            Builder.AppendLine("<trackbacks />");
            Builder.AppendLine("</post>");
            return Builder.ToString();
        }

        #endregion
    }
}