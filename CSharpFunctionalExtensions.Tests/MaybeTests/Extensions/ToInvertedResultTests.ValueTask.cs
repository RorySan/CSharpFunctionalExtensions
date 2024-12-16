﻿using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class ToInvertedResultTests_ValueTask : MaybeTestBase
    {
        [Fact]
        public async Task ToInvertedResult_ValueTask_returns_failure_if_has_value()
        {
            var maybe = Maybe<T>.From(T.Value);

            var result = await maybe.AsValueTask().ToInvertedResult("Error");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Error");
        }
        
        [Fact]
        public async Task ToInvertedResult_ValueTask_returns_success_if_has_no_value()
        {
            Maybe<T> maybe = null;

            var result = await maybe.AsValueTask().ToInvertedResult("Error");

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task ToInvertedResult_ValueTask_returns_custom_failure_if_has_value()
        {
            var maybe = Maybe<T>.From(T.Value);

            var result = await maybe.AsValueTask().ToInvertedResult(E.Value);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value);
        }
        
        [Fact]
        public async Task ToInvertedResult_ValueTask_custom_failure_returns_success_if_has_no_value()
        {
            Maybe<T> maybe = null;

            var result = await maybe.AsValueTask().ToInvertedResult(E.Value);

            result.IsSuccess.Should().BeTrue();
        }
    }
}
