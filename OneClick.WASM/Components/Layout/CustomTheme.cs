﻿using MudBlazor;

namespace OneClick.WASM.Components.Layout
{
    public static class CustomTheme
    {
        public static MudTheme MyTheme => new()
        {
            PaletteLight = new PaletteLight()
            {
                Primary = "#4361ee",
                PrimaryDarken = "#4361ee",
                PrimaryLighten = "#515365",
                Secondary = "#888ea8",
                SecondaryLighten = "#d3d3d3",
                SecondaryDarken = "#515365",
                Tertiary = "#f1f2f3", //bg block
                Dark = "#f1f2f3",
                AppbarBackground = "#0e1726",
                Background = "#f1f2f3",


            },
            PaletteDark = new PaletteDark()
            {
                Primary = "#4682b4",
                PrimaryDarken = "#4682b4",
                PrimaryLighten = "#f1f2f3",
                Secondary = "#242f3d",
                SecondaryLighten = "#4c607b", //бледный текст
                SecondaryDarken = "#ffffffb2", // текст на темном фоне
                Tertiary = "#1a1c2d",
                Background = "#060818",
                Surface = "#0e1726",//cust block
                Dark = "#060818",//sidebar
                AppbarBackground = "#060818",

            },

            //Typography = new Typography()
            //{

            //}
        };
    }
}
