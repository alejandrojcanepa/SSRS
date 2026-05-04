# Validation

This document defines the validation path for SSRS changes.

## Current profile

SSRS currently contains reporting-related assets and experiments.

There is no maintained local installer, build, or executable validation runner in the current repository state.

## Connector checks

From the GitHub connector, verify:

```text
README attribution
AGENTS.md
Copilot instructions
validation documentation
changelog entries
.gitignore coverage
text hygiene
```

## Documentation review

For documentation-only changes, review the changed Markdown for clarity, scope, and absence of credentials, generated outputs, or machine-specific files.

## Runtime checks

There are no required runtime checks while the repository remains documentation/reporting assets only.

If executable report tooling is added later, update this document with the required setup and validation path.
