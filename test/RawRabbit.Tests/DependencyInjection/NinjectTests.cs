﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ninject;
using RawRabbit.Context;
using Xunit;
using RawRabbit.DependencyInjection.Ninject;

namespace RawRabbit.Tests.DependencyInjection
{
	public class NinjectTests
	{
		[Fact]
		public void Should_Be_Able_To_Resolve_IBusClient()
		{
			/* Setup */
			var kernel = new StandardKernel();
			kernel.RegisterRawRabbit("guest:guest@localhost:5672/");

			/* Test */
			var client = kernel.Get<IBusClient>();
			client.Dispose();

			/* Assert */
			Assert.True(true, "Could resolve");
		}

		[Fact]
		public void Should_Be_Able_To_Resolve_BusClient_With_Advanced_Context()
		{
			/* Setup */
			var kernel = new StandardKernel();
			kernel.RegisterRawRabbit<AdvancedMessageContext>("guest:guest@localhost:5672/");

			/* Test */
			var client = kernel.Get<IBusClient<AdvancedMessageContext>>();
			client.Dispose();

			/* Assert */
			Assert.True(true, "Could resolve");
		}
	}
}
