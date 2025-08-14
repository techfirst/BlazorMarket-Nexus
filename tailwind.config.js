/** @type {import('tailwindcss').Config} */
module.exports = {
  darkMode: 'class',
  content: [
    './src/Nexus/**/*.{razor,html,cshtml}',
    './src/Nexus/Components/**/*.{razor,html,cshtml}',
    './src/Nexus/wwwroot/index.html',
    './src/Nexus/wwwroot/**/*.js'
  ],
  theme: {
    extend: {
      colors: {
        'nexus-blue': 'var(--nexus-blue)',
        'nexus-blue-dark': 'var(--nexus-blue-dark)',
        'nexus-blue-light': 'var(--nexus-blue-light)',
        'nexus-gray': 'var(--bg-secondary)',
        'nexus-dark': 'var(--text-primary)',
        'nexus-light-gray': 'var(--bg-tertiary)',
      },
      fontFamily: {
        'sans': ['Inter', '-apple-system', 'BlinkMacSystemFont', 'Segoe UI', 'Roboto', 'system-ui', 'sans-serif'],
      },
      fontWeight: {
        'light': '300',
        'normal': '400',
        'medium': '500',
        'semibold': '600',
        'bold': '700',
      }
    }
  },
  plugins: []
}