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
import { ProcessorLogWhereInput } from "./ProcessorLogWhereInput";
import { ValidateNested, IsOptional } from "class-validator";
import { Type } from "class-transformer";

@InputType()
class ProcessorLogListRelationFilter {
  @ApiProperty({
    required: false,
    type: () => ProcessorLogWhereInput,
  })
  @ValidateNested()
  @Type(() => ProcessorLogWhereInput)
  @IsOptional()
  @Field(() => ProcessorLogWhereInput, {
    nullable: true,
  })
  every?: ProcessorLogWhereInput;

  @ApiProperty({
    required: false,
    type: () => ProcessorLogWhereInput,
  })
  @ValidateNested()
  @Type(() => ProcessorLogWhereInput)
  @IsOptional()
  @Field(() => ProcessorLogWhereInput, {
    nullable: true,
  })
  some?: ProcessorLogWhereInput;

  @ApiProperty({
    required: false,
    type: () => ProcessorLogWhereInput,
  })
  @ValidateNested()
  @Type(() => ProcessorLogWhereInput)
  @IsOptional()
  @Field(() => ProcessorLogWhereInput, {
    nullable: true,
  })
  none?: ProcessorLogWhereInput;
}
export { ProcessorLogListRelationFilter as ProcessorLogListRelationFilter };
