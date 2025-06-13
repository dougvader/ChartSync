module.exports = {
  content: [
    "./Pages/**/*.razor",
    "./Shared/**/*.razor",
    "./wwwroot/**/*.html",
    "./wwwroot/**/*.cshtml"
  ],
  theme: {
    extend: {
      colors: {
        brand: { DEFAULT: "#19cb98", dark: "#161C24" }
      }
    }
  },
  plugins: [
    require('@tailwindcss/forms'),
    require('@tailwindcss/typography'),
    require('@tailwindcss/aspect-ratio')
  ],
};
