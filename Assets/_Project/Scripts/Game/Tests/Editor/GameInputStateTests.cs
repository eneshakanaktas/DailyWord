using NUnit.Framework;

namespace DailyWord.Game.Tests
{
    public sealed class GameInputStateTests
    {
        [Test]
        public void AddLetter_FillsCurrentRowInOrder()
        {
            GameInputState state = new GameInputState();

            Assert.That(state.TryAddLetter("Q", out int firstRow, out int firstColumn), Is.True);
            Assert.That(state.TryAddLetter("İ", out int secondRow, out int secondColumn), Is.True);

            Assert.That(firstRow, Is.EqualTo(0));
            Assert.That(firstColumn, Is.EqualTo(0));
            Assert.That(secondRow, Is.EqualTo(0));
            Assert.That(secondColumn, Is.EqualTo(1));
            Assert.That(state.GetLetter(0, 0), Is.EqualTo("Q"));
            Assert.That(state.GetLetter(0, 1), Is.EqualTo("İ"));
        }

        [Test]
        public void AddLetter_DoesNotNormalizeTurkishI()
        {
            GameInputState state = new GameInputState();

            state.TryAddLetter("I", out _, out _);
            state.TryAddLetter("İ", out _, out _);
            state.TryAddLetter("ı", out _, out _);
            state.TryAddLetter("i", out _, out _);

            Assert.That(state.GetLetter(0, 0), Is.EqualTo("I"));
            Assert.That(state.GetLetter(0, 1), Is.EqualTo("İ"));
            Assert.That(state.GetLetter(0, 2), Is.EqualTo("ı"));
            Assert.That(state.GetLetter(0, 3), Is.EqualTo("i"));
        }

        [Test]
        public void AddLetter_StopsAtFiveLetters()
        {
            GameInputState state = new GameInputState();

            foreach (string letter in new[] { "K", "A", "L", "E", "M" })
            {
                Assert.That(state.TryAddLetter(letter, out _, out _), Is.True);
            }

            Assert.That(state.TryAddLetter("X", out _, out _), Is.False);
            Assert.That(state.TryGetCurrentGuess(out string guess), Is.True);
            Assert.That(guess, Is.EqualTo("KALEM"));
        }

        [Test]
        public void Backspace_ClearsLastLetterAndAllowsReplacement()
        {
            GameInputState state = new GameInputState();

            state.TryAddLetter("K", out _, out _);
            state.TryAddLetter("A", out _, out _);

            Assert.That(state.TryBackspace(out int row, out int column), Is.True);
            Assert.That(row, Is.EqualTo(0));
            Assert.That(column, Is.EqualTo(1));
            Assert.That(state.GetLetter(0, 1), Is.Empty);

            state.TryAddLetter("İ", out _, out _);
            Assert.That(state.GetLetter(0, 1), Is.EqualTo("İ"));
        }

        [Test]
        public void Backspace_OnEmptyRow_DoesNothing()
        {
            GameInputState state = new GameInputState();

            Assert.That(state.TryBackspace(out _, out _), Is.False);
            Assert.That(state.ActiveColumn, Is.EqualTo(0));
            Assert.That(state.ActiveRow, Is.EqualTo(0));
        }

        [Test]
        public void EnterReadyGuess_RequiresFullRow()
        {
            GameInputState state = new GameInputState();

            state.TryAddLetter("K", out _, out _);
            Assert.That(state.TryGetCurrentGuess(out _), Is.False);

            foreach (string letter in new[] { "A", "L", "E", "M" })
            {
                state.TryAddLetter(letter, out _, out _);
            }

            Assert.That(state.TryGetCurrentGuess(out string guess), Is.True);
            Assert.That(guess, Is.EqualTo("KALEM"));
        }

        [Test]
        public void AdvanceRow_DoesNotMovePastSixRows()
        {
            GameInputState state = new GameInputState();

            for (int row = 0; row < 6; row++)
            {
                foreach (string letter in new[] { "K", "A", "L", "E", "M" })
                {
                    Assert.That(state.TryAddLetter(letter, out _, out _), Is.True);
                }

                state.TryAdvanceRow();
            }

            Assert.That(state.IsComplete, Is.True);
            Assert.That(state.TryAddLetter("X", out _, out _), Is.False);
        }
    }
}
