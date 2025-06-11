module.exports = {
  content: ["./**/*.razor", "./**/*.html", "./**/*.cshtml"],
  theme: {
    extend: {
      colors: {
        brand: { DEFAULT: "#19cb98", dark: "#161C24" }
      }
    }
  },
  plugins: [require('@tailwindcss/forms'), require('@tailwindcss/typography'), require('@tailwindcss/aspect-ratio')],
};
