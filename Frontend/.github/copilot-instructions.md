<!-- Use this file to provide workspace-specific custom instructions to Copilot. For more details, visit https://code.visualstudio.com/docs/copilot/copilot-customization#_use-a-githubcopilotinstructionsmd-file -->

# NBC News-Style Landing Page Instructions

This Angular project implements a news application landing page that mimics the layout and design of NBC News. The application follows modern responsive web design practices and utilizes Angular's component-based architecture.

## Project Structure

- **Top News Banner**: Red notification bar at the top with current headlines
- **Header Navigation**: Primary navigation with NBC logo and main sections
- **Topic Navigation**: Horizontal scrolling topics bar
- **Main Content Area**: Grid layout with featured news and secondary stories
- **Sidebar**: Latest news and live streaming sections

## Styling Guidelines

- **Color Palette**:
  - Primary Red: `#c00` (Used for banner, accent elements)
  - Dark Blue/Black: `#1a1a2e` (Used for header background)
  - Accent Yellow: `#f7c948` (Used for highlights, "WATCH" button, exclusive tags)
  - Text Black: `#000` (Main content)
  - Text Gray: `#444` (Secondary text)
  - Background Gray: `#f9f9f9` (Page background)
  - White: `#fff` (Cards, content areas)

- **Typography**:
  - Font Family: Roboto, Arial, sans-serif
  - Header sizes: Featured (2rem), Secondary (1.5rem), Sidebar (1.1rem)
  - Body text: 1rem for main content, 0.95rem for summaries

- **Component Styling**:
  - Cards use subtle shadows: `box-shadow: 0 1px 3px rgba(0,0,0,0.1)`
  - Rounded corners: `border-radius: 4px`
  - Live indicators use small red circles

## Layout Structure

The layout uses CSS Grid for the main container:
```scss
.main-container {
  display: grid;
  grid-template-columns: 1fr 350px;
  gap: 2rem;
}
```

Responsive breakpoints:
- Desktop: Full layout
- Tablet (<992px): Stacked main content and side-by-side sidebar sections
- Mobile (<768px): Single column layout with hidden main navigation

## Components and Features

When extending this application:

1. **News Items**: Each news item should include headline, optional summary, and optional image
2. **Live Indicators**: Use the `.live-indicator` class for real-time content
3. **Navigation**: Main navigation links should use uppercase text
4. **Time Indicators**: Use relative time formatting (e.g., "42m ago")

## Best Practices

- Maintain semantic HTML structure for accessibility
- Keep responsive design in mind when adding new components
- Use SCSS nesting for component styling
- Follow the existing naming conventions for CSS classes
- Placeholder images should be replaced with actual content in production

## Data Structure

News items typically follow this structure:
```typescript
interface NewsItem {
  headline: string;
  summary?: string;
  imageUrl?: string;
  isLive?: boolean;
  isExclusive?: boolean;
  timePublished?: Date;
}
```

## Future Enhancements

When suggesting improvements or adding features to this application, consider:

1. Adding a news article component with detailed view
2. Implementing dark mode toggle
3. Adding search functionality
4. Creating category-based filtering
5. Adding animation for smooth transitions between views
6. Implementing a weather widget in the sidebar