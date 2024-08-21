# Purpose

Testing behavior describe in [godot issue 8545](https://github.com/godotengine/godot/issues/85459).

# Steps

To observe the problematic behaviors, follow these steps.

## Working Correctly / As Expected

1. Open scene `test_resource_nesting_basic`
2. Build the project
3. Click the root node
4. Click the button to assign a resource to `Resource Head`
5. Create a new resource
6. Create a new child resource in the `Resource Child` field
7. Create a new child resource in the `Resource Grand Child` field
8. Set the `Y` property on `Resource Grand Child`

The above steps all work smoothly, no issue here.

## Fail to Add Child Resources to `Resource Head`

1. Open scene `test_resource_nesting_with_defaults`
2. Build the project
3. Click the root node
4. Note that a resource is already assigned to `Resource Head` and expand it
5. Create a new child resource in the `Resource Child` field
6. Open the `Output` message panel and note the message **_Unable to cast object of type 'Godot.Resource' to type 'ResourceChild'_**

For an additional interesting test, right click and `Clear` the `Resource Head` resource, then create a new one. The new resource will behave the same as the first test.

## Fail to Add Child Resource to Nested Resource

This one is essentially the same thing as the last test, but at a lower level. I created this one to verify the same behavior was present when a default child resource is assigned to a Resource, not just at the Node level.

1. Open scene `test_resource_nesting_with_defaults`
2. Build the project
3. Click the root node
4. Create a new child resource in the `Resource Head` field
5. Note that `Resource Child` has already been filled and expand it
6. Create a new child resource in the `Resource Grand Child` field
7. Open the `Output` message panel and note the message **_Unable to cast object of type 'Godot.Resource' to type 'ResourceGrandChild'_**

## Fail to Add Child to \[Tool\] Resources

This test, and the next tests, all just verify that \[Tool\] scripts cause the same behavior as a default using `new MyResource()`. Spoiler: It does.

1. Open scene `test_resource_testing_with_tool_scripts`
2. Build the project
3. Click the root node
4. Create a new child resource in `Resource Head` field
5. Create a new child resource in `Resource Child` field
6. Open the `Output` message panel and note the message **_Unable to cast object of type 'Godot.Resource' to type 'ResourceChild'_**

## Fail to Add Grand Child to \[Tool\] Resources

This test is pretty much the same as the former, but for the grand child. The reason I added this test was to verify the problem would not be mitigated by making sure a \[Tool\] was instantiating a \[Tool\]. In this test `Resource Child` is a \[Tool\] and so is `Resource Grand Child`. I felt there was a chance that going \[Tool\] -> \[Tool\] might have been a workaround.

1. Open scene `test_resource_testing_with_tool_scripts`
2. Build the project
3. Click the root node
4. Create a new child resource in `Resource Head` field
5. Create a new child resource in `Resource Child` field
6. Create a new child resource in `Resource Grand Child` field
6. Open the `Output` message panel and note the message **_Unable to cast object of type 'Godot.Resource' to type 'ResourceGrandChild'_**

## Fail to Add Child to \[Tool\] Resources

This test verifies that adding \[Tool\] to the Node itself doesn't mitigate the issue.

1. Open scene `test_resource_testing_with_tool_scripts`
2. Build the project
3. Click the root node
4. Create a new child resource in `Resource Head` field
5. Create a new child resource in `Resource Child` field
6. Open the `Output` message panel and note the message **_Unable to cast object of type 'Godot.Resource' to type 'ResourceChild'_**