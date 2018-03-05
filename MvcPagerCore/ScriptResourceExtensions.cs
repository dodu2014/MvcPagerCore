/* MvcPager source code
This file is part of MvcPager.
Copyright 2009-2017 Webdiyer(http://en.webdiyer.com)
Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
    http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Webdiyer.WebControls.AspNetCore
{
	///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/Classes/Class[@name = "ScriptResourceExtensions"]/*'/>
	public static  class ScriptResourceExtensions
	{

		///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/ScriptResourceExtensions/Method[@name="RegisterMvcPagerScriptResource"]/*'/>
		public static IHtmlContent RegisterMvcPagerScriptResource(this IHtmlHelper helper) {
			var result = new TagBuilder("script");
			var embeddedProvider = new EmbeddedFileProvider(Assembly.GetExecutingAssembly()); //获取正在运行代码的程序集
			IFileInfo fileInfo = embeddedProvider.GetFileInfo("MvcPager.min.js"); //区分大小写
			if (fileInfo is null || !fileInfo.Exists) {
				result.Attributes.Add("src", "");
			} else {
				var stream = fileInfo.CreateReadStream();
				result.Attributes.Add("src", "data:application/javascript;base64," + stream.ToBase64String());
			}
			return result;
		}
	}
}
