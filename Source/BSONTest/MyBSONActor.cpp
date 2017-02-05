// Fill out your copyright notice in the Description page of Project Settings.

#include "BSONTest.h"
#include "MyBSONActor.h"


// Sets default values
AMyBSONActor::AMyBSONActor()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

// Called when the game starts or when spawned
void AMyBSONActor::BeginPlay()
{
	Super::BeginPlay();
	UE_LOG(LogTemp, Warning, TEXT("BeginPlay in MyBSONActor"));
	bson_t parent;
	bson_t child;
	char *str;

	bson_init(&parent);
	bson_append_document_begin(&parent, "foo", 3, &child);
	bson_append_int32(&child, "baz", 3, 1);
	bson_append_document_end(&parent, &child);

	str = bson_as_json(&parent, NULL);
	FString fstr = FString(UTF8_TO_TCHAR(str));
	UE_LOG(LogTemp, Warning, TEXT("BSON Output: %s"), *fstr);
	bson_free(str);

	bson_destroy(&parent);
	UE_LOG(LogTemp, Warning, TEXT("BSON destroyed in BeginPlay in MyBSONActor"));
}

// Called every frame
void AMyBSONActor::Tick( float DeltaTime )
{
	Super::Tick( DeltaTime );

}

