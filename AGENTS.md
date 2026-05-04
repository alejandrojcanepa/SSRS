# SSRS agent instructions

This repository is part of the Epsilon toolset.

Before using the GitHub connector against this repository, consult `Epsilon-Consulting/agent-runbook`, especially `docs/github-connector/` and `docs/repository-standards/`.

## Repository purpose

SSRS contains reporting-related assets and experiments.

## Operating rules

Use `master` as the canonical branch unless the user explicitly asks for another branch.

Keep changes scoped and documented. Do not add local build, install, or validation launchers unless the repository gains executable tooling that requires them.

Do not commit secrets, generated caches, generated report outputs, credentials, or machine-specific files.

Keep README attribution unchanged unless explicitly requested.

## Validation

Read `docs/validation.md` before changing repository content. If validation cannot run from the connector, state what was checked and what remains for local or runtime review.
