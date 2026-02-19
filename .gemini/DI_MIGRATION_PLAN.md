# Dependency Injection Migration Plan

## Overview
This document outlines the step-by-step migration from static factories to Dependency Injection (DI) pattern.

## Migration Phases

### Phase 1: Infrastructure Setup ✓
- [x] Create DI container configuration
- [x] Create abstraction interfaces
- [x] Add Microsoft.Extensions.DependencyInjection NuGet package
- [x] Create ServiceProvider infrastructure

### Phase 2: Core Abstractions
- [ ] Create IGenericCommands interface
- [ ] Create IRptGenericCommands interface
- [ ] Create IConnectionProvider interface
- [ ] Update GenericCommands to implement interface
- [ ] Update RptGenericCommands to implement interface

### Phase 3: Factory Conversion
- [ ] Convert Factory (Core) to RepositoryFactory service
- [ ] Convert BudgetFactory to BudgetRepositoryFactory service
- [ ] Convert AccountingFactory to AccountingRepositoryFactory service
- [ ] Convert TreasuryFactory to TreasuryRepositoryFactory service
- [ ] Convert RptFactory to RptRepositoryFactory service

### Phase 4: Repository Registration
- [ ] Register all Core repositories
- [ ] Register all Budget repositories
- [ ] Register all Accounting repositories
- [ ] Register all Treasury repositories
- [ ] Register all RPT repositories

### Phase 5: Application Integration
- [ ] Create ServiceLocator for WinForms compatibility
- [ ] Update Program.cs to initialize DI container
- [ ] Update frmSignIn to use DI
- [ ] Update frmMain to use DI
- [ ] Update all forms to use DI

### Phase 6: Testing & Cleanup
- [ ] Test all database operations
- [ ] Remove old static factories
- [ ] Remove ServerRepository classes
- [ ] Update documentation

## Breaking Changes

### Before (Static)
```csharp
var repo = Factory.UsersRepository();
var users = repo.GetAll();
```

### After (DI)
```csharp
var factory = ServiceLocator.GetService<IRepositoryFactory>();
var repo = factory.UsersRepository();
var users = repo.GetAll();
```

## Rollback Plan
If issues arise, we can:
1. Keep both old and new implementations temporarily
2. Use feature flags to switch between them
3. Gradually migrate form by form

## Estimated Effort
- Phase 1-2: 2-3 hours
- Phase 3-4: 4-6 hours
- Phase 5: 3-4 hours
- Phase 6: 2-3 hours
**Total: 11-16 hours**

## Benefits After Migration
✅ Testable code (can mock dependencies)
✅ Proper lifecycle management
✅ Support for multiple database contexts
✅ Modern, maintainable architecture
✅ Easier to add new features
✅ Better error handling
