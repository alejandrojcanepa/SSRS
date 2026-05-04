# SSRS instructions for AI coding agents

This repository follows the Epsilon Agent Ready standard.

Read `README.md`, `AGENTS.md`, and `docs/validation.md` before proposing or writing changes.

Use `Epsilon-Consulting/agent-runbook` as the canonical connector playbook for issue workflow, write policy, validation expectations, and lessons learned.

## Project context

SSRS contains reporting-related assets and experiments.

## Development expectations

Keep changes scoped, documented, and reversible. Avoid unrelated refactors.

Do not commit secrets, generated report outputs, generated caches, machine-specific files, or credentials.

## Validation expectations

Run or document the validation described in `docs/validation.md`. If a check cannot run from the connector environment, say so clearly and identify the remaining local validation.
