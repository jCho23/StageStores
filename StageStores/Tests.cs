using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;

namespace StageStores
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void Repl()
		{
			app.Repl();
		}

		[Test]
		public void FirstTest()
		{
			app.Tap("todays_deals_text");
			app.Screenshot("Tapped on 'Today's Deals'");
			app.WaitForElement(x => x.Id("expires"), timeout: TimeSpan.FromSeconds(80));

			app.ScrollDown();
			app.Screenshot("Scrolling down to see more coupons");
			app.Back();

			app.Tap("browse_text");
			app.Screenshot("Tapped on 'Browse & Shop'");

			app.Tap("women");
			app.Screenshot("Tapped on 'Women'");

			app.Tap("sweaters");
			app.Screenshot("Tapped on 'Sweaters'");
			app.Back();
			app.Screenshot("Tapped on Back Button");

			app.Tap("jeans");
			app.Screenshot("Tapped on 'Jeans'");
			app.Back();
			app.Screenshot("Tapped on Back Button");

			app.Tap("tops");
			app.Screenshot("Tapped on 'Tops'");
			app.WaitForElement(x => x.Id("yes_suffix"), timeout: TimeSpan.FromSeconds(80));

			app.Tap(x => x.Marked("yes_suffix"));
			app.Screenshot("Tapped on 'Chaus Metallic Design Top'");
			app.WaitForElement(x => x.Id("color_label"), timeout: TimeSpan.FromSeconds(80));

			app.Tap("S");
			app.Screenshot("Tapped on my size, 'S'");

			app.Tap("add_to_bag_button");
			app.Screenshot("Tapped on 'Add to Bag' Button");

			app.WaitForElement(x => x.Id("color_label"), timeout: TimeSpan.FromSeconds(80));
			Thread.Sleep(4000);
			app.Tap("cart_image");
			app.Screenshot("Tapped on my shopping cart");
		}

	}
}
