/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { InputType, Field } from "@nestjs/graphql";
import { ProcessorLogWhereUniqueInput } from "../../processorLog/base/ProcessorLogWhereUniqueInput";
import { ApiProperty } from "@nestjs/swagger";

@InputType()
class ProcessorLogUpdateManyWithoutMessageQueuesInput {
  @Field(() => [ProcessorLogWhereUniqueInput], {
    nullable: true,
  })
  @ApiProperty({
    required: false,
    type: () => [ProcessorLogWhereUniqueInput],
  })
  connect?: Array<ProcessorLogWhereUniqueInput>;

  @Field(() => [ProcessorLogWhereUniqueInput], {
    nullable: true,
  })
  @ApiProperty({
    required: false,
    type: () => [ProcessorLogWhereUniqueInput],
  })
  disconnect?: Array<ProcessorLogWhereUniqueInput>;

  @Field(() => [ProcessorLogWhereUniqueInput], {
    nullable: true,
  })
  @ApiProperty({
    required: false,
    type: () => [ProcessorLogWhereUniqueInput],
  })
  set?: Array<ProcessorLogWhereUniqueInput>;
}

export { ProcessorLogUpdateManyWithoutMessageQueuesInput as ProcessorLogUpdateManyWithoutMessageQueuesInput };