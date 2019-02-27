using System;
namespace Maptz.Text.DummyText
{

    public class DummyWordGenerator : IDummyWordGenerator
    {
        public const string DummyTextSource = @"Lorem ipsum dolor sit amet consectetur adipiscing elit Etiam iaculis turpis sit amet dolor dignissim ac bibendum ex fermentum Aliquam tortor lorem lobortis quis ullamcorper sed gravida quis leo Pellentesque convallis interdum lorem sed faucibus Maecenas semper placerat metus sed sagittis Nunc aliquet lorem tellus non mollis sapien aliquam luctus Nam at tristique augue Etiam congue pellentesque urna vel pretium diam dictum vel Mauris rhoncus nisi in ante tempus et ultrices mi volutpat Donec vel volutpat sem nec varius turpis Proin pretium lorem sed ipsum eleifend eu finibus nisl volutpat Fusce faucibus elementum iaculis Nunc lobortis eros pharetra scelerisque euismod dui nisl egestas arcu nec accumsan dolor lectus non nisi Sed suscipit ornare vulputate Proin a lorem id nulla tristique porttitor Proin consectetur eros neque a egestas augue suscipit eu Curabitur vitae neque eget lectus tristique maximus Lorem ipsum dolor sit amet consectetur adipiscing elit Cras et mauris vel eros porta sagittis sed eu est Aenean in mauris vel ex egestas condimentum Aliquam porttitor est elementum laoreet ligula vitae blandit leo Fusce massa leo pulvinar eget interdum iaculis malesuada ut urna Duis posuere egestas ante sit amet fermentum dolor tincidunt sed Nam ut porta lorem Pellentesque finibus nulla risus eget faucibus ligula laoreet et Praesent id auctor ligula Nam eu magna augue Suspendisse potenti Phasellus blandit sapien felis vitae lacinia elit posuere a Maecenas cursus molestie sollicitudin Morbi luctus dui vitae nulla scelerisque egestas Nunc vitae est at sem mattis bibendum Maecenas elementum rhoncus risus eu porta enim sollicitudin sed Vivamus commodo justo vitae lacus porttitor suscipit Integer at venenatis nulla In consequat porttitor neque nec commodo lectus tincidunt vitae Etiam nec leo odio Mauris dignissim mauris in tristique mollis In sit amet sollicitudin arcu id aliquam diam Fusce posuere massa eget nibh faucibus consectetur Donec eget lorem ut nisl tristique rutrum non in ipsum In et gravida augue Curabitur convallis cursus sapien sed rutrum Maecenas nec auctor arcu et interdum nisl Quisque pellentesque euismod ex in blandit orci interdum vel Vivamus tincidunt orci sit amet ante fringilla sodales Aenean varius felis non magna imperdiet consectetur Donec consectetur tempus laoreet Praesent laoreet ac arcu ac ullamcorper Mauris bibendum lorem id orci maximus mollis Nulla facilisi Ut rhoncus ante vel nulla aliquam tincidunt Donec at ultrices enim quis dapibus eros Nullam gravida sem eget porttitor imperdiet lacus enim dictum ex auctor laoreet enim ante ut tortor Sed a mattis urna Mauris posuere enim ante id dapibus elit lobortis eget Nunc at erat eu augue consectetur viverra Ut ut magna non arcu hendrerit posuere In eu purus nec ligula ultrices cursus Aenean ullamcorper eros eget lacus finibus molestie Nunc mattis libero at odio molestie pellentesque Ut sed justo iaculis viverra velit vitae ornare magna";
        public DummyWordGenerator() : this(null)
        {

        }

        public DummyWordGenerator(int? seed)
        {
            this.Random = seed.HasValue ? new Random(seed.Value) : new Random();
        }

        public Random Random { get; private set; }

        public string NextWord()
        {
            var words = DummyTextSource.Split(' ');
            var nextWordIndex = this.Random.Next(words.Length);
            var nextWord = words[nextWordIndex].ToLower();
            return nextWord;
        }
    }
}