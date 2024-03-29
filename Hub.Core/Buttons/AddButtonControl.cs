﻿using Hub.Core.Decorators;
using System.Threading.Tasks;

namespace Hub.Core.Buttons
{
    public class AddButtonControl
    {
        private readonly IPageDecorator _page;
        public AddButtonControl(IPageDecorator page)
        {
            _page = page;
        }

        private string AddButton => "text='Add'";
        private string ItemSelector(string text) => $@"a:has-text('{text}')";
        public async Task GoToActivity(string level1, string level2 = null)
        {
            await _page.ClickAsync(AddButton);

            await _page.Locator($"{ItemSelector(level1)} >> nth=0").HoverAsync();

            if (level2 != null)
                await _page.Locator($"{ItemSelector(level2)} >> nth=2").ClickAsync();
        }
    }
}
