// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

// TODO Portability

#include "AllowWindowsPlatformTypes.h"
#include "bson.h"
#include "HideWindowsPlatformTypes.h"

#include "MyBSONActor.generated.h"

UCLASS()
class BSONTEST_API AMyBSONActor : public AActor
//class  AMyBSONActor : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AMyBSONActor();

	// Called when the game starts or when spawned
	virtual void BeginPlay() override;
	
	// Called every frame
	virtual void Tick( float DeltaSeconds ) override;

	
	
};
