# Tailwind CSS Setup Guide

This project uses Tailwind CSS with a proper build process instead of the CDN for better performance and optimization.

## Prerequisites

- Node.js (version 16 or higher)
- npm (comes with Node.js)

## Quick Start

1. **Install dependencies** (if not already done):
   ```bash
   npm install
   ```

2. **Build CSS for production**:
   ```bash
   npm run build-css
   ```

3. **Development with live CSS updates**:
   ```bash
   npm run watch-css
   ```

## How It Works

- **Input file**: `src/Nexus/wwwroot/css/input.css` contains Tailwind directives and custom CSS
- **Output file**: `src/Nexus/wwwroot/css/app.css` (generated, don't edit directly)
- **Configuration**: `tailwind.config.js` defines content paths and custom theme
- **Build integration**: MSBuild automatically runs CSS build before .NET build/publish

## Troubleshooting

### Build Error: "npm run build-css exited with code 1"

**Cause**: Node.js/npm not available in build environment

**Solutions**:
1. **Install Node.js**: Download from https://nodejs.org/
2. **Manual build**: Run `npm run build-css` manually before building the project
3. **Check PATH**: Ensure Node.js is in your system PATH

### Missing Styles

**Cause**: CSS not built or output file not found

**Solutions**:
1. Run `npm run build-css`
2. Check that `src/Nexus/wwwroot/css/app.css` exists
3. Verify `input.css` contains your styles

### Development Workflow

For active development:
1. Run `npm run watch-css` in a terminal
2. Start your Blazor application in another terminal
3. Tailwind will automatically rebuild CSS when you modify classes

### Manual Build Process

If automatic building isn't working:
1. `npm install` (ensure dependencies are installed)
2. `npm run build-css` (build CSS)
3. Build/run your Blazor project normally

## File Structure

```
nexus/
├── package.json              # npm configuration and scripts
├── tailwind.config.js        # Tailwind configuration
├── postcss.config.js         # PostCSS configuration
└── src/Nexus/wwwroot/css/
    ├── input.css              # Source CSS with Tailwind directives
    └── app.css               # Generated CSS (don't edit)
```

## Customization

- **Colors/Fonts**: Edit `tailwind.config.js`
- **Custom CSS**: Add to `src/Nexus/wwwroot/css/input.css`
- **Build process**: Modify scripts in `package.json`