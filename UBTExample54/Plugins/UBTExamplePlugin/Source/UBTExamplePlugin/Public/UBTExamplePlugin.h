// Copyright Kittehface Software 2024

#pragma once

#include "CoreMinimal.h"
#include "Modules/ModuleManager.h"

class FUBTExamplePluginModule : public IModuleInterface
{
public:

	virtual void StartupModule() override;
	virtual void ShutdownModule() override;
};
