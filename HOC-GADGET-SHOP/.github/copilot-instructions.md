# Copilot Instructions for HOC-GADGET-SHOP

## Project Overview
- This is an Angular application generated with Angular CLI v20.2.2.
- The main entry point is `src/main.ts`, with the root module and routing in `src/app/app.ts` and `src/app/app.routes.ts`.
- Components are organized under `src/app/AppComponent/`, with feature folders (e.g., `invertory/`).

## Architecture & Patterns
- Follows standard Angular structure: modules, components, templates, and styles.
- Each feature (e.g., `invertory`) has its own folder containing `.ts`, `.html`, `.css`, and `.spec.ts` files.
- Routing is managed in `app.routes.ts`.
- Shared configuration is in `app.config.ts`.
- Use Angular CLI for scaffolding new components/services (`ng generate component <name>`).

## Developer Workflows
- **Start Dev Server:** `ng serve` (auto-reloads on file changes)
- **Build:** `ng build` (outputs to `dist/`)
- **Unit Tests:** `ng test` (Karma runner)
- **E2E Tests:** `ng e2e` (framework not included by default)
- **Scaffold:** `ng generate component <name>`

## Conventions & Practices
- Place new features/components in their own subfolders under `src/app/AppComponent/`.
- Use `.spec.ts` files for unit tests, colocated with the component/service.
- Styles are per-component (`.css` next to `.ts`/`.html`).
- Keep global styles in `src/styles.css`.
- Use Angular CLI commands for all major operations (scaffolding, build, test).

## Integration Points
- No custom backend or API integration detected in the current structure.
- External dependencies managed via `package.json`.
- Static assets (e.g., favicon) in `public/`.

## Examples
- To add an inventory feature: create a folder under `AppComponent/`, add `invertory.ts`, `invertory.html`, `invertory.css`, and update routing in `app.routes.ts`.
- To run tests for a component: use `ng test` after editing the relevant `.spec.ts` file.

## Key Files & Directories
- `src/app/app.ts`, `app.routes.ts`, `app.config.ts`: Application setup and routing
- `src/app/AppComponent/`: Main components/features
- `src/styles.css`: Global styles
- `public/`: Static assets

---
For more details, see the README.md or visit https://angular.dev/tools/cli for Angular CLI documentation.

---
**If any conventions or workflows are unclear, please provide feedback so this guide can be improved.**
