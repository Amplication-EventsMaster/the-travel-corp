/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { InputType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { Type } from "class-transformer";
import { IsOptional, ValidateNested, IsEnum } from "class-validator";
import { StringFilter } from "../../util/StringFilter";
import { NotificationAttemptListRelationFilter } from "../../notificationAttempt/base/NotificationAttemptListRelationFilter";
import { IntNullableFilter } from "../../util/IntNullableFilter";
import { ProcessorLogListRelationFilter } from "../../processorLog/base/ProcessorLogListRelationFilter";
import { EnumMessageQueueStatus } from "./EnumMessageQueueStatus";

@InputType()
class MessageQueueWhereInput {
  @ApiProperty({
    required: false,
    type: StringNullableFilter,
  })
  @Type(() => StringNullableFilter)
  @IsOptional()
  @Field(() => StringNullableFilter, {
    nullable: true,
  })
  comment?: StringNullableFilter;

  @ApiProperty({
    required: false,
    type: StringFilter,
  })
  @Type(() => StringFilter)
  @IsOptional()
  @Field(() => StringFilter, {
    nullable: true,
  })
  id?: StringFilter;

  @ApiProperty({
    required: false,
    type: () => NotificationAttemptListRelationFilter,
  })
  @ValidateNested()
  @Type(() => NotificationAttemptListRelationFilter)
  @IsOptional()
  @Field(() => NotificationAttemptListRelationFilter, {
    nullable: true,
  })
  notificationAttempts?: NotificationAttemptListRelationFilter;

  @ApiProperty({
    required: false,
    type: IntNullableFilter,
  })
  @Type(() => IntNullableFilter)
  @IsOptional()
  @Field(() => IntNullableFilter, {
    nullable: true,
  })
  priority?: IntNullableFilter;

  @ApiProperty({
    required: false,
    type: () => ProcessorLogListRelationFilter,
  })
  @ValidateNested()
  @Type(() => ProcessorLogListRelationFilter)
  @IsOptional()
  @Field(() => ProcessorLogListRelationFilter, {
    nullable: true,
  })
  processorLogs?: ProcessorLogListRelationFilter;

  @ApiProperty({
    required: false,
    type: StringNullableFilter,
  })
  @Type(() => StringNullableFilter)
  @IsOptional()
  @Field(() => StringNullableFilter, {
    nullable: true,
  })
  queueName?: StringNullableFilter;

  @ApiProperty({
    required: false,
    enum: EnumMessageQueueStatus,
  })
  @IsEnum(EnumMessageQueueStatus)
  @IsOptional()
  @Field(() => EnumMessageQueueStatus, {
    nullable: true,
  })
  status?: "Option1";
}

export { MessageQueueWhereInput as MessageQueueWhereInput };
